namespace Services.CartService
{
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;
    using Models.Enums;

    using ViewModels.Cart;
    using ViewModels.Courier;

    public class CartService : ICartService
    {
        private readonly ApplicationDbContext data;
        private IMapper mapper;

        public CartService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<CartResultModel> AddAsync(string userId, int gunId)
        {
            var gun = await this.data.Guns.FirstOrDefaultAsync(x => x.Id == gunId);
            var client = await data.Users
                .Where(x => x.Id == userId)
                .Include(x => x.Client)
                .ThenInclude(x => x.Cart)
                .ThenInclude(x => x.Guns)
                .FirstOrDefaultAsync();

            if (gun == null)
            {
                return null;
            }

            if (client.Client.CartId == null)
            {
                client.Client.Cart = new Cart();
            }

            client.Client.Cart.Guns.Add(gun);
            await data.SaveChangesAsync();

            var result = new CartResultModel
            {
                CartId = client.Client.CartId,
                ItemsCount = client.Client.Cart.Guns.Count
            };

            return result;
        }

        public async Task<ICollection<CartViewModel>> GetItemsInCartAsync(string userId)
        {
            var userGuns = await this.data.Users
                           .Where(x => x.Id == userId)
                           .SelectMany(x => x.Client.Cart.Guns)
                           .Include(x => x.Image)
                           .ToListAsync();

            var result = this.mapper.Map<List<CartViewModel>>(userGuns);

            return result;
        }

        public async Task<bool> DeleteItemByIdAsync(string userId, int itemId)
        {
            var user = await this.data.Users
                .Where(x => x.Id == userId)
                .Include(x => x.Client)
                .ThenInclude(x => x.Cart)
                .ThenInclude(x => x.Guns)
                .FirstAsync();

            var userCart = user.Client.Cart;

            if (userCart != null)
            {
                var gun = userCart.Guns.FirstOrDefault(x => x.Id == itemId);
                if (gun != null)
                {
                    var result = userCart.Guns.Remove(gun);
                    await this.data.SaveChangesAsync();

                    return result;
                }

                return false;
            }

            return false;
        }

        public async Task<NavCartModel> GetCartData(string userId)
        {
            var guns = await this.data.Users
                        .Where(x => x.Id == userId)
                        .Include(x => x.Client)
                        .ThenInclude(x => x.Cart)
                        .ThenInclude(x => x.Guns)
                        .Select(x => x.Client.Cart.Guns)
                        .FirstOrDefaultAsync();

            var count = guns != null ? guns.Count : 0;
            var price = 0m;

            if (guns != null)
            {
                foreach (var gun in guns)
                {
                    price += gun.Price;
                }
            }

            var model = new NavCartModel()
            {
                ItemsCount = count,
                TotalPrice = price
            };

            return model;
        }

        public async Task<CartDeliveryDataViewModel> GetCartDeliveryDataAsync()
        {
            var couriers = await this.data.Couriers
                .Where(x => x.IsDeleted == null)
                .ProjectTo<CourierViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            var deliveryData = new CartDeliveryDataViewModel();

            foreach (var courier in couriers)
            {
                deliveryData.Couriers.Add(courier);
            }

            deliveryData.CashPayment = PaymentType.Cash.ToString();
            deliveryData.CardPayment = PaymentType.Card.ToString();

            return deliveryData;
        }
    }
}

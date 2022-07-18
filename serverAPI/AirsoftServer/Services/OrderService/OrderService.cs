namespace Services.OrderService
{
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;
    using Models.Enums;

    using ViewModels.Item.Guns;
    using ViewModels.Order;

    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public OrderService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<bool> CreateOrderAsync(string userId, OrderInputModel model)
        {
            var user = await this.data.Users
                .Where(x => x.Id == userId)
                .Include(x => x.Client)
                .FirstAsync();

            var courier = await this.data.Couriers
                .FirstOrDefaultAsync(x => x.Id == model.CourierId);

            var guns = new List<Gun>();
            for (int i = 0; i < model.GunsIds.Count; i++)
            {
                var gun = await this.data.Guns
                    .FirstOrDefaultAsync(x => x.Id == model.GunsIds[i]);

                guns.Add(gun);
            }

            var dealers = await this.data.Dealers
                .ToListAsync();

            foreach (var dealer in dealers)
            {
                var order = new Order();

                foreach (var gun in guns)
                {
                    if (dealer.Id == gun.DealerId)
                    {
                        order.ClientId = user.ClientId;
                        order.PaymentType = model.PaymentType == "cash" ? PaymentType.Cash : PaymentType.Card;
                        order.OrderStatus = OrderStatus.Processing;
                        order.Dealers.Add(dealer);
                        order.Guns.Add(gun);
                        order.TotalPrice += gun.Price;
                        order.CourierId = model.CourierId;
                    }
                }

                if (order.Guns.Count > 0)
                {
                    user.Client.Orders.Add(order);
                }
            }

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<OrderListModel>> GetUserOrdersAsync(string userId)
        {
            var user = await this.data.Users
                .Where(x => x.Id == userId)
                .Include(x => x.Client)
                .ThenInclude(x => x.Orders)
                .ThenInclude(x => x.Guns)
                .ThenInclude(x => x.Image)
                .FirstOrDefaultAsync();

            var result = new List<OrderListModel>();

            foreach (var order in user.Client.Orders)
            {
                var orderList = new OrderListModel()
                {
                    OrderId = order.Id,
                    CreatedOn = order.CreatedOn.ToString("dd/MM/yyyy"),
                    TotalPrice = order.TotalPrice
                };

                if (order.Guns.Count > 0)
                {
                    var gun = order.Guns.First();
                    var gunModel = this.mapper.Map<OrderGunsViewModel>(gun);
                    orderList.Gun = gunModel;
                    result.Add(orderList);
                }

            }

            return result;
        }

        public async Task<OrderDetailsModel> GetOrderDetails(string userId, string orderId)
        {
            var clientId = await this.data.Users
                .Where(x => x.Id == userId)
                .Select(x => x.ClientId)
                .FirstOrDefaultAsync();

            var orderDetails = await this.data.Orders
                .Where(x => x.Id == orderId && x.ClientId == clientId && x.IsDeleted == null)
                .OrderByDescending(x => x.CreatedOn)
                .ProjectTo<OrderDetailsModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return orderDetails;
        }
    }
}

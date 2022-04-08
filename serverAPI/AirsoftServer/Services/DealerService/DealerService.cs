namespace Services.DealerService
{
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;

    using ViewModels.Dealer;
    using ViewModels.User;

    public class DealerService : IDealerService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public DealerService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<string> CreateDealerAsync(DealerInputModel model)
        {
            var city = await this.data.Cities
                .FirstOrDefaultAsync(x => x.Name == model.CityName);

            if (city is null)
            {
                return "0";
            }

            var dealer = new Dealer
            {
                Name = model.Name,
                DealerNumber = model.DealerNumber,
                Email = model.Email,
                PhoneNumber = model.Phone,
                Address = new Address
                {
                    StreetName = model.StreetName,
                    CityId = city.Id
                },
                SiteUrl = model.SiteUrl
            };

            await this.data.Dealers.AddAsync(dealer);
            await this.data.SaveChangesAsync();

            return dealer.Id;
        }

        public async Task<UserDealerViewModel> GetDealerDataAsync(string id)
            => await this.data.Users
                        .Where(x => x.Id == id)
                        .ProjectTo<UserDealerViewModel>(this.mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();
    }
}

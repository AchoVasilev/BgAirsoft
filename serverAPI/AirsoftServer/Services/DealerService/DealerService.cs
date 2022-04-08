namespace Services.DealerService
{
    using System.Threading.Tasks;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;

    using ViewModels.Dealer;

    public class DealerService : IDealerService
    {
        private readonly ApplicationDbContext data;

        public DealerService(ApplicationDbContext data)
        {
            this.data = data;
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
                }
            };

            await this.data.Dealers.AddAsync(dealer);
            await this.data.SaveChangesAsync();

            return dealer.Id;
        }
    }
}

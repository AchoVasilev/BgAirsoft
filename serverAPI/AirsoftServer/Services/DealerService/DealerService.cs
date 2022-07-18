namespace Services.DealerService
{
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Models;

    using ViewModels.Dealer;
    using ViewModels.User;

    public class DealerService : IDealerService
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public DealerService(ApplicationDbContext data, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.data = data;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateDealerAsync(DealerInputModel model, string imageId)
        {
            var city = await this.data.Cities
                .FirstOrDefaultAsync(x => x.Name == model.CityName);

            if (city is null)
            {
                var error = new IdentityError()
                {
                    Description = "Няма такъв град",
                    Code = "400"
                };

                return IdentityResult.Failed(new IdentityError[1] { error });
            }

            var applicationUser = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Username,
                ImageId = imageId,
                Dealer = new Dealer
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
                }
            };

            var result = await this.userManager.CreateAsync(applicationUser, model.Password);

            if (result.Succeeded)
            {
                await this.data.SaveChangesAsync();
                return result;
            }

            return result;
        }

        public async Task<UserDealerViewModel> GetDealerDataAsync(string id)
            => await this.data.Users
                        .Where(x => x.Id == id)
                        .ProjectTo<UserDealerViewModel>(this.mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();
    }
}

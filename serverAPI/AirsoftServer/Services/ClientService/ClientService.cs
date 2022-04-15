namespace Services.ClientService
{
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Models;

    using ViewModels.Client;
    using ViewModels.User;

    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext data;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public ClientService(ApplicationDbContext data, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.data = data;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateClientAsync(ClientInputModel model)
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
                Image = new Image
                {
                    Url = "https://res.cloudinary.com/dpo3vbxnl/image/upload/v1649172192/BgAirsoft/NoAvatarProfileImage_uj0zyg.png",
                    Extension = "png",
                    Name = "NoAvatarProfileImage"
                },
                Client = new Client
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    Address = new Address
                    {
                        StreetName = model.StreetName,
                        CityId = city.Id
                    }
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

        public async Task<bool> EditClient(string userId, EditClientModel model)
        {
            var user = await this.data.Users
                .Where(x => x.Id == userId)
                .Include(x => x.Client)
                .ThenInclude(x => x.Address)
                .FirstOrDefaultAsync();

            var city = await this.data.Cities
                .FirstOrDefaultAsync(x => x.Name == model.CityName);

            if (user == null || city == null)
            {
                return false;
            }

            user.Client.Address.StreetName = model.StreetName;
            user.Client.Address.CityId = city.Id;
            user.Client.FirstName = model.FirstName;
            user.Client.LastName = model.LastName;
            user.Email = model.Email;
            user.Client.Email = model.Email;
            user.Client.PhoneNumber = model.Phone;

            user.Client.ModifiedOn = DateTime.UtcNow;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UserIsClient(string userId)
        {
            var result = await this.data.Users.FirstOrDefaultAsync(x => x.Id == userId && x.ClientId != null);

            if (result == null)
            {
                return false;
            }

            return true;
        }

        public async Task<UserClientViewModel> GetClientDataAsync(string userId)
            => await this.data.Users
                .Where(x => x.Id == userId)
                .ProjectTo<UserClientViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
    }
}

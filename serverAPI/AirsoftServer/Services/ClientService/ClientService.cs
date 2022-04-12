namespace Services.ClientService
{
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;

    using ViewModels.Client;
    using ViewModels.User;

    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public ClientService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<string> CreateClientAsync(ClientInputModel model)
        {
            var city = await this.data.Cities
                .FirstOrDefaultAsync(x => x.Name == model.CityName);

            if (city is null)
            {
                return "0";
            }

            var client = new Client
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
            };

            await this.data.Clients.AddAsync(client);
            await this.data.SaveChangesAsync();

            return client.Id;
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

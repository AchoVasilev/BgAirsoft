namespace Services.ClientService
{
    using System;
    using System.Threading.Tasks;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;

    using ViewModels.Client;

    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext data;

        public ClientService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<string> CreateClientAsync(ClientInputModel model)
        {
            var city = await this.data.Cities
                .FirstOrDefaultAsync(x => x.Name == model.Address.CityName);

            if (city is null)
            {
                return null;
            }

            var client = new Client
            {
                FirstName = model.FirstName,
                LasttName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = new Address
                {
                    StreetName = model.Address.StreetName,
                    CityId = city.Id
                }
            };

            await this.data.Clients.AddAsync(client);
            await this.data.SaveChangesAsync();

            return client.Id;
        }
    }
}

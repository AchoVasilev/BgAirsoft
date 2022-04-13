﻿namespace Services.ClientService
{
    using ViewModels.Client;
    using ViewModels.User;

    public interface IClientService
    {
        Task<string> CreateClientAsync(ClientInputModel model);

        Task<UserClientViewModel> GetClientDataAsync(string userId);

        Task<bool> UserIsClient(string userId);

        Task<bool> EditClient(string userId, EditClientModel model);
    }
}

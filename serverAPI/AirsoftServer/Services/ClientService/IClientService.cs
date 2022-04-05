namespace Services.ClientService
{
    using ViewModels.Client;

    public interface IClientService
    {
        Task<string> CreateClientAsync(ClientInputModel model);
    }
}

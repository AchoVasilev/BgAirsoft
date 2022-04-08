namespace ViewModels.User
{
    using ViewModels.Client;
    using ViewModels.Images;

    public class UserClientViewModel
    {
        public string Id { get; init; }

        public string Email { get; init; }

        public string UserName { get; init; }

        public string ClientId { get; init; }

        public ClientViewModel Client { get; init; }

        public ImageViewModel Image { get; init; }
    }
}

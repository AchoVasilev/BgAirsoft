namespace ViewModels.User
{
    using ViewModels.Dealer;
    using ViewModels.Images;

    public class UserDealerViewModel
    {
        public string Id { get; init; }

        public string Email { get; init; }

        public string UserName { get; init; }

        public string DealerId { get; init; }

        public DealerViewModel Dealer { get; init; }

        public ImageViewModel Image { get; init; }
    }
}

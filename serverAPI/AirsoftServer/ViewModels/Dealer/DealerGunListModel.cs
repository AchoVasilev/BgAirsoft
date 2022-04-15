namespace ViewModels.Dealer
{
    using ViewModels.Images;
    using ViewModels.Order;

    public class DealerGunListModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Color { get; init; }

        public decimal Price { get; init; }

        public string Manufacturer { get; init; }

        public string CreatedOn { get; init; }

        public string DealerId { get; init; }

        public ImageViewModel Image { get; init; }
    }
}

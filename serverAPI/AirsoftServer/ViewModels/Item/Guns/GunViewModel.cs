namespace ViewModels.Item.Guns
{
    using ViewModels.Images;

    public class GunViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string DealerName { get; init; }

        public string DealerSiteUrl { get; init; }

        public string Manufacturer { get; init; }

        public string Color { get; init; }

        public double Power { get; init; }

        public ImageViewModel Image { get; init; }
    }
}

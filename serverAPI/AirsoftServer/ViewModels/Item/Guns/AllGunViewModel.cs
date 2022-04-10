namespace ViewModels.Item.Guns
{
    using ViewModels.Images;

    public class AllGunViewModel
    {
        public int Id { get; init; }

        public string DealerName { get; init; }

        public string Name { get; init; }

        public string Manufacturer { get; init; }

        public double Weight { get; init; }

        public string Propulsion { get; init; }

        public double Power { get; init; }

        public string Color { get; init; }

        public decimal Price { get; init; }

        public ImageViewModel Image { get; init; }
    }
}

namespace ViewModels.Item.Guns
{
    using ViewModels.Images;

    public class OrderGunViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public ImageViewModel Image { get; set; }
    }
}

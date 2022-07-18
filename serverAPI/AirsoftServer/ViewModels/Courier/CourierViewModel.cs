namespace ViewModels.Courier
{

    using ViewModels.Images;

    public class CourierViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public decimal DeliveryPrice { get; init; }

        public int DeliveryDays { get; init; }

        public ImageViewModel Image { get; init; }
    }
}

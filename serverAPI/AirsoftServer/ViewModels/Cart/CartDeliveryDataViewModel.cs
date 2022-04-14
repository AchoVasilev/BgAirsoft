namespace ViewModels.Cart
{
    using ViewModels.Courier;

    public class CartDeliveryDataViewModel
    {
        public ICollection<CourierViewModel> Couriers { get; set; } = new List<CourierViewModel>();

        public string CashPayment { get; set; }

        public string CardPayment { get; set; }
    }
}

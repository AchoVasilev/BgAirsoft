namespace ViewModels.Order
{
    using System.Collections.Generic;

    using ViewModels.Courier;

    public class OrderDetailsModel
    {
        public string Id { get; init; }

        public decimal TotalPrice { get; init; }

        public CourierOrderViewModel Courier { get; init; }

        public ICollection<OrderGunsViewModel> Guns { get; init; }

        public string PaymentType { get; init; }

        public string OrderStatus { get; init; }
    }
}

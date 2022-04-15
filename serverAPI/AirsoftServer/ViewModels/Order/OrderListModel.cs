namespace ViewModels.Order
{
    public class OrderListModel
    {
        public string OrderId { get; set; }

        public string CreatedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public OrderGunsViewModel Gun { get; set; }
    }
}

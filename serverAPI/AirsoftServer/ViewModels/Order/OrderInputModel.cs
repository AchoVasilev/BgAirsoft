namespace ViewModels.Order
{
    using System.Collections.Generic;

    public class OrderInputModel
    {
        public string PaymentType { get; set; }

        public decimal TotalPrice { get; set; }

        public int CourierId { get; set; }

        public List<int> GunsIds{ get;set; }
    }
}

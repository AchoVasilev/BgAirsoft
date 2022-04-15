namespace Services.OrderService
{
    using ViewModels.Order;

    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(string userId, OrderInputModel model);

        Task<ICollection<OrderListModel>> GetUserOrdersAsync(string userId);

        Task<OrderDetailsModel> GetOrderDetails(string userId, string orderId);
    }
}

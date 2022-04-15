namespace Services.CartService
{
    using System.Threading.Tasks;

    using ViewModels.Cart;

    public interface ICartService
    {
        Task<CartResultModel> AddAsync(string userId, int gunId);

        Task<ICollection<CartViewModel>> GetItemsInCartAsync(string userId);

        Task<bool> DeleteItemByIdAsync(string userId, int itemId);

        Task<NavCartModel> GetCartData(string userId);

        Task<CartDeliveryDataViewModel> GetCartDeliveryDataAsync();

        Task<bool> ClearCartAsync(string userId);
    }
}

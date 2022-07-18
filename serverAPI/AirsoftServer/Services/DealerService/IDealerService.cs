namespace Services.DealerService
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using ViewModels.Dealer;
    using ViewModels.User;

    public interface IDealerService
    {
        Task<IdentityResult> CreateDealerAsync(DealerInputModel model, string imageId);

        Task<UserDealerViewModel> GetDealerDataAsync(string id);
    }
}

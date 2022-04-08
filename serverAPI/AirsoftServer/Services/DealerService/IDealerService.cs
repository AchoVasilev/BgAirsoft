namespace Services.DealerService
{
    using System.Threading.Tasks;

    using ViewModels.Dealer;
    using ViewModels.User;

    public interface IDealerService
    {
        Task<string> CreateDealerAsync(DealerInputModel model);

        Task<UserDealerViewModel> GetDealerDataAsync(string id);
    }
}

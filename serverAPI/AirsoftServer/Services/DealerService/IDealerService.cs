namespace Services.DealerService
{
    using System.Threading.Tasks;

    using ViewModels.Dealer;

    public interface IDealerService
    {
        Task<string> CreateDealerAsync(DealerInputModel model);
    }
}

namespace Services.ProductService
{
    using System.Threading.Tasks;

    using ViewModels.Dealer;
    using ViewModels.Item.Guns;

    public interface IProductService
    {
        Task<int> CreateGunAsync(GunInputModel model, string dealerId, string imageId);

        Task<ICollection<GunViewModel>> GetNewestEightGunsAsync();

        Task<GunDetailsModel> GetGunDetailsAsync(int gunId);

        Task<ICollection<AllGunViewModel>> GetAllGunsAsync();

        Task<ICollection<AllGunViewModel>> FilterGunsByManufacturerAsync(List<string> query);

        Task<ICollection<AllGunViewModel>> FilterGunsByDealerAsync(List<string> query);

        Task<ICollection<AllGunViewModel>> FilterGunsByColorAsync(List<string> query);

        Task<ICollection<AllGunViewModel>> FilterGunsByPowerAsync(GunQueryModel query);

        Task<ICollection<AllGunViewModel>> FilterGunsByCategoryAsync(GunQueryModel query);

        Task<ICollection<AllGunViewModel>> OrderGuns(GunSortModel model);

        Task<ICollection<AllGunViewModel>> GetAllGunsAsync(AllGunsQueryModel query);

        Task<int> GetAllGunsCount();

        Task<ICollection<string>> GetAllColors();

        Task<ICollection<string>> GetAllDealers();

        Task<ICollection<string>> GetAllManufacturers();

        Task<ICollection<double>> GetAllPowers();

        Task<bool> EditAsync(string userId, GunEditModel model);

        Task<bool> DeleteGunAsync(int gunId);

        Task<ICollection<DealerGunListModel>> GetMyProducts(string userId);
    }
}

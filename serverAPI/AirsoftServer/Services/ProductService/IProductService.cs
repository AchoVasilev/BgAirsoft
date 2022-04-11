namespace Services.ProductService
{
    using System.Threading.Tasks;

    using ViewModels.Item.Guns;

    public interface IProductService
    {
        Task<int> CreateGunAsync(GunInputModel model, string dealerId, string imageId);

        Task<ICollection<GunViewModel>> GetNewestEightGunsAsync();

        Task<ICollection<AllGunViewModel>> GetAllGunsAsync();

        Task<ICollection<AllGunViewModel>> FilterGunsByManufacturerAsync(List<string> query);

        Task<ICollection<AllGunViewModel>> FilterGunsByDealerAsync(List<string> query);

        Task<ICollection<AllGunViewModel>> FilterGunsByColorAsync(List<string> query);

        Task<ICollection<AllGunViewModel>> FilterGunsByPowerAsync(GunQueryModel query);

        Task<ICollection<AllGunViewModel>> FilterGunsByCategoryAsync(GunQueryModel query);

        Task<ICollection<AllGunViewModel>> OrderGuns(GunSortModel model);
    }
}

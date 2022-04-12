namespace AirsoftServer.MappingProfile
{
    using AutoMapper;

    using Models;

    using ViewModels.Address;
    using ViewModels.Cart;
    using ViewModels.Categories;
    using ViewModels.City;
    using ViewModels.Client;
    using ViewModels.Dealer;
    using ViewModels.Images;
    using ViewModels.Item.Guns;
    using ViewModels.User;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CategoryViewModel>();
            this.CreateMap<Category, BasicCategoryViewModel>();
            this.CreateMap<SubCategory, SubcategoryViewModel>();

            this.CreateMap<Image, ImageViewModel>();

            this.CreateMap<City, CityViewModel>();

            this.CreateMap<ApplicationUser, UserClientViewModel>();
            this.CreateMap<ApplicationUser, UserDealerViewModel>();

            this.CreateMap<Client, ClientViewModel>();
            this.CreateMap<Dealer, DealerViewModel>();
            this.CreateMap<Address, AddressViewModel>();

            this.CreateMap<Gun, GunViewModel>();
            this.CreateMap<Gun, AllGunViewModel>();
            this.CreateMap<Gun, CartViewModel>();
        }
    }
}

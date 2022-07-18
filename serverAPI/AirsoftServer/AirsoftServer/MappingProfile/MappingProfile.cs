namespace AirsoftServer.MappingProfile
{
    using AutoMapper;

    using Models;

    using ViewModels.Address;
    using ViewModels.Cart;
    using ViewModels.Categories;
    using ViewModels.City;
    using ViewModels.Client;
    using ViewModels.Courier;
    using ViewModels.Dealer;
    using ViewModels.Images;
    using ViewModels.Item.Guns;
    using ViewModels.Order;
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
            this.CreateMap<Dealer, OrderDealerViewModel>();

            this.CreateMap<Address, AddressViewModel>();

            this.CreateMap<Gun, GunViewModel>();
            this.CreateMap<Gun, AllGunViewModel>();
            this.CreateMap<Gun, CartViewModel>();
            this.CreateMap<Gun, OrderGunViewModel>();
            this.CreateMap<Gun, OrderGunsViewModel>();
            this.CreateMap<Gun, GunDetailsModel>();
            this.CreateMap<Gun, DealerGunListModel>();

            this.CreateMap<Courier, CourierViewModel>();
            this.CreateMap<Courier, CourierOrderViewModel>();

            this.CreateMap<Order, OrderDetailsModel>();
        }
    }
}

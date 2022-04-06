namespace AirsoftServer.MappingProfile
{
    using AutoMapper;

    using Models;

    using ViewModels.Categories;
    using ViewModels.City;
    using ViewModels.Images;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, CategoryViewModel>();
            this.CreateMap<SubCategory, SubcategoryViewModel>();

            this.CreateMap<Image, ImageViewModel>();

            this.CreateMap<City, CityViewModel>();
        }
    }
}

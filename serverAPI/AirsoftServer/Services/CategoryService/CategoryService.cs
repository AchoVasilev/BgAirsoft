namespace Services.CategoryService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using ViewModels.Categories;

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public CategoryService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<ICollection<CategoryViewModel>> GetAllCategoriesAsync()
            => await this.data.Categories
                .Where(x => x.IsDeleted == null)
                .ProjectTo<CategoryViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<ICollection<BasicCategoryViewModel>> GetFourNewestCategoriesAsync()
            => await this.data.Categories
                    .Where(x => x.IsDeleted == null)
                    .OrderBy(x => x.CreatedOn)
                    .Take(4)
                    .ProjectTo<BasicCategoryViewModel>(this.mapper.ConfigurationProvider)
                    .ToListAsync();

        public async Task<ICollection<SubcategoryViewModel>> GetGunSubCategoriesAsync()
            => await this.data.SubCategories
                        .Where(x => x.Category.Name == "Еърсофт оръжия" && x.IsDeleted == null)
                        .ProjectTo<SubcategoryViewModel>(this.mapper.ConfigurationProvider)
                        .ToListAsync();
    }
}

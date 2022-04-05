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
    }
}

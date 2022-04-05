namespace Services.CategoryService
{
    using ViewModels.Categories;

    public interface ICategoryService
    {
        Task<ICollection<CategoryViewModel>> GetAllCategoriesAsync();
    }
}

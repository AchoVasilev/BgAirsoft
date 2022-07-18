namespace ViewModels.Categories
{
    using ViewModels.Images;

    public class CategoryViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string ImageId { get; init; }

        public ImageViewModel Image { get; init; }

        public ICollection<SubcategoryViewModel> SubCategories { get; init; }
    }
}

namespace ViewModels.Item.Guns
{
    public class GunQueryModel
    {
        public List<string>? Manufacturers { get; set; } = null;

        public List<string>? Dealers { get; set; } = null;

        public List<string>? Colors { get; set; } = null;

        public List<double>? Powers { get; set; } = null;

        public string? CategoryName { get; set; } = null;
    }
}

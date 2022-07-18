namespace ViewModels.Item.Guns
{
    public class AllGunsViewModel
    {
        public ICollection<AllGunViewModel> AllGuns { get; set; }

        public ICollection<string> Colors { get; set; }

        public ICollection<string> Dealers { get; set; }

        public ICollection<string> Manufacturers { get; set; }

        public ICollection<double> Powers { get; set; }
    }
}

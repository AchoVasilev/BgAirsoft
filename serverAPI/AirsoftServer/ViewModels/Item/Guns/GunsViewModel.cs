namespace ViewModels.Item.Guns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GunsViewModel : PagingModel
    {
        public ICollection<AllGunViewModel> AllGuns { get; set; }

        public ICollection<string> Colors { get; set; }

        public ICollection<string> Dealers { get; set; }

        public ICollection<string> Manufacturers { get; set; }

        public ICollection<double> Powers { get; set; }
    }
}

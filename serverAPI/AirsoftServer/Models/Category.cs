namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Models.Base;

    using static GlobalConstants.Constants;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.SubCategories = new HashSet<SubCategory>();
        }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Image))]
        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}

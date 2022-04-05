namespace Models
{
    using System.ComponentModel.DataAnnotations;

    using Models.Base;

    using static GlobalConstants.Constants;

    public class SubCategory : BaseModel<int>
    {
        public SubCategory()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}

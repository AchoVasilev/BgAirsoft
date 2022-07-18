namespace Models
{
    using Models.Base;
    using Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static GlobalConstants.Constants;

    public class Gun : BaseModel<int>
    {
        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Manufacturer { get; set; }

        [Required]
        [ForeignKey(nameof(Image))]
        public string ImageId { get; set; }

        public virtual Image Image { get; set; }

        [MaxLength(DataConstants.RangeMaxLength)]
        public double Power { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Color { get; set; }

        [MaxLength(DataConstants.NumbersMaxLength)]
        public double Weight { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Magazine { get; set; }

        [Required]
        [MaxLength(DataConstants.RangeMaxLength)]
        public int Capacity { get; set; }

        [Required]
        [MaxLength(DataConstants.RangeMaxLength)]
        public int Speed { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Firing { get; set; }

        [Required]
        [MaxLength(DataConstants.NumbersMaxLength)]
        public int Length { get; set; }

        [Required]
        [MaxLength(DataConstants.NumbersMaxLength)]
        public int Barrel { get; set; }

        public Propulsion Propulsion { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Material { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Blowback { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Hopup { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Dealer))]
        public string DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
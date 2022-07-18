namespace Models
{
    using System.ComponentModel.DataAnnotations;

    using Models.Base;

    using static GlobalConstants.Constants;

    public class City : BaseModel<int>
    {
        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataConstants.NumbersMaxLength)]
        public int ZipCode { get; set; }
    }
}
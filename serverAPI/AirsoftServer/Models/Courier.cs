namespace Models
{
    using System.ComponentModel.DataAnnotations;

    using Models.Base;

    using static GlobalConstants.Constants;
    public class Courier : BaseModel<int>
    {
        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Name { get; set; }

        public decimal DeliveryPrice { get; set; }

        public int DeliveryDays { get; set; }
    }
}

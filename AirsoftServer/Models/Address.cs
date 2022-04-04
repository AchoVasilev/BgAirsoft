namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Models.Base;

    using static GlobalConstants.Constants;

    public class Address : BaseModel<int>
    {
        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string StreetName { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        [ForeignKey(nameof(Dealer))]
        public string DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }
    }
}

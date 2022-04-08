namespace Models
{
    using static GlobalConstants.Constants;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Models.Base;

    public class Dealer : BaseModel<string>
    {
        public Dealer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Guns = new HashSet<Gun>();
            this.Fields = new HashSet<Field>();
        }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string DealerNumber { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string SiteUrl { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }

        public virtual ICollection<Field> Fields { get; set; }
    }
}

namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Models.Base;

    using static GlobalConstants.Constants;

    public class Dealer : BaseModel<string>
    {
        public Dealer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Guns = new HashSet<Gun>();
            this.Fields = new HashSet<Field>();
            this.Orders = new HashSet<Order>();
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

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }

        public virtual ICollection<Field> Fields { get; set; }
    }
}

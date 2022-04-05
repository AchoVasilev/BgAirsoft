namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using Models.Base;

    using static GlobalConstants.Constants;

    public class UnregisteredClient : BaseModel<string>
    {
        public UnregisteredClient()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string LasttName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}

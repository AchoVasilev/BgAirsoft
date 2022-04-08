namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Models.Base;

    using static GlobalConstants.Constants;

    public class Client : BaseModel<string>
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataConstants.DefaultMaxLength)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public virtual Cart Cart { get; set; }

        [ForeignKey(nameof(WishList))]
        public string WishListId { get; set; }

        public virtual WishList WishList { get; set; }
    }
}

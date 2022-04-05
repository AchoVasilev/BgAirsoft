namespace ViewModels.Client
{
    using System.ComponentModel.DataAnnotations;

    using ViewModels.Address;

    using static GlobalConstants.Constants;

    public class ClientInputModel
    {
        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string LastName { get; set; }

        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Username { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public AddressInputModel Address { get; set; }

        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.PasswordMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Password { get; set; }
    }
}

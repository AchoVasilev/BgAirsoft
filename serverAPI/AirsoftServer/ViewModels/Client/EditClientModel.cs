namespace ViewModels.Client
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.Constants;

    public class EditClientModel
    {
        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string CityName { get; set; }
    }
}

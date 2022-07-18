namespace ViewModels.User
{
using static GlobalConstants.Constants;
using System.ComponentModel.DataAnnotations;

    public class LoginInputModel
    {
        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Username { get; set; }

        [Required]
        [MinLength(DataConstants.DefaultMinLength)]
        public string Password { get; set; }
    }
}

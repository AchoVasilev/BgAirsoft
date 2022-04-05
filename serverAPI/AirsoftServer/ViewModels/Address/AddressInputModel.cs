namespace ViewModels.Address
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.Constants;

    public class AddressInputModel
    {
        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string CityName { get; set; }
    }
}

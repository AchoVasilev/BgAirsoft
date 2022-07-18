namespace ViewModels.Item.Guns
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.Constants;
    using Microsoft.AspNetCore.Http;

    public class GunInputModel
    {
        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Name { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Manufacturer { get; set; }

        public IFormFile Image { get; set; }

        [Range(DataConstants.RangeMinLength, DataConstants.RangeMaxLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public double Power { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Color { get; set; }

        [Range(DataConstants.RangeMinLength, maximum:DataConstants.NumbersMaxLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public double Weight { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Magazine { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [Range(DataConstants.RangeMinLength, DataConstants.RangeMaxLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public int Capacity { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [Range(DataConstants.RangeMinLength, DataConstants.RangeMaxLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public int Speed { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Firing { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [Range(DataConstants.RangeMinLength, DataConstants.NumbersMaxLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public int Length { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [Range(DataConstants.RangeMinLength, DataConstants.NumbersMaxLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public int Barrel { get; set; }

        public string Propulsion { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Material { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Blowback { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string Hopup { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = MessageConstants.RequiredFieldErrorMsg)]
        [StringLength(DataConstants.DefaultMaxLength, MinimumLength = DataConstants.DefaultMinLength, ErrorMessage = MessageConstants.LengthErrorMsg)]
        public string SubCategoryName { get; set; }
    }
}

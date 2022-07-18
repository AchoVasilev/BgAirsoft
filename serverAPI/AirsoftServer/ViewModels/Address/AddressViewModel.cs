namespace ViewModels.Address
{
    using ViewModels.City;

    public class AddressViewModel
    {
        public string StreetName { get; init; }

        public CityViewModel City { get; init; }
    }
}

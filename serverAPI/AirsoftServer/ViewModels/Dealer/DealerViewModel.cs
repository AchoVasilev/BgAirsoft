namespace ViewModels.Dealer
{
using ViewModels.Address;

    public class DealerViewModel
    {
        public string Name { get; init; }

        public string DealerNumber { get; init; }

        public string PhoneNumber { get; init; }

        public string SiteUrl { get; init; }

        public AddressViewModel Address { get; init; }
    }
}

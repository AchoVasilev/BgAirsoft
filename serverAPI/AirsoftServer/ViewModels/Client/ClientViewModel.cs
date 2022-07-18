namespace ViewModels.Client
{
    using ViewModels.Address;

    public class ClientViewModel
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string PhoneNumber { get; init; }

        public AddressViewModel Address { get; init; }
    }
}

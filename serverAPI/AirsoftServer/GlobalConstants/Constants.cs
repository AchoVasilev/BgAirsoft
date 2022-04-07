namespace GlobalConstants
{
    public static class Constants
    {
        public const string AppUri = "http://localhost:4200";

        public static class DataConstants
        {
            public const int DefaultMinLength = 2;
            public const int DefaultMaxLength = 40;

            public const int AddressMaxLength = 50;
            public const int DescriptionMaxLength = 1000;

            public const int RangeMinLength = 1;
            public const int RangeMaxLength = 999;

            public const int NumbersMaxLength = 9999;

            public const int PasswordMinLength = 6;
        }

        public static class MessageConstants
        {
            public const string RequiredFieldErrorMsg = "Полето е задължително.";
            public const string LengthErrorMsg = "Полето трябва да е между {0} и {1} символа.";
            public const string PasswordLengthErrorMsg = "Паролата трябва да е между {0} {1} символа.";
            public const string PasswordsNotMatchErrorMsg = "Паролите не съвпадат.";

            public const string IvalidEmailErrorMsg = "Моля въведете валиден и-мейл адрес.";

            public const string UnsuccessfulActionMsg = "Нещо се обърка, опитайте пак.";
            public const string SuccessfulDeleteMsg = "Изтриването беше успешно.";
            public const string SuccessfulEditMsg = "Промяната беше успешна.";

            public const string SuccessfulAddedItemMsg = "Успешно добавяне.";

            public const string InvalidCityMsg = "Избрали сте невалиден град";

            public const string FailedUserLogin = "Невалиден потребител или парола";
        }
    }
}
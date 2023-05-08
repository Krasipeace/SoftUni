namespace Invoices.Data.Common
{
    public static class ValidationConstants
    {
        // Product
        public const int ProductNameMaxLength = 30;
        public const int ProductNameMinLength = 9;

        public const decimal ProductPriceMaxValue = 1000.0m;
        public const decimal ProductPriceMinValue = 5.0m;

        // Address
        public const int StreetNameMaxLength = 20;
        public const int StreetNameMinLength = 10;

        public const int CityMaxLength = 15;
        public const int CityMinLength = 5;

        public const int CountryMaxLength = 15;
        public const int CountryMinLength = 5;

        // Client
        public const int ClientNameMaxLength = 25;
        public const int ClientNameMinLength = 10;

        public const int ClientNumberVatMaxLength = 15;
        public const int ClientNumberVatMinLength = 10;

        // Invoice
        public const int InvoiceNumberMaxValue = 1500000000; // 1_500_000_000
        public const int InvoiceNumberMinValue = 1000000000; // 1_000_000_000
    }
}

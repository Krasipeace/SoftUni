namespace Invoices.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Data.Common;

    [XmlType("Address")]
    public class ImportAddressDto
    {
        [Required]
        [XmlElement("StreetName")]
        [MaxLength(ValidationConstants.StreetNameMaxLength)]
        [MinLength(ValidationConstants.StreetNameMinLength)]
        public string StreetName { get; set; } = null!;

        [Required]
        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }

        [Required]
        [XmlElement("PostCode")]
        public string PostCode { get; set; } = null!;

        [Required]
        [XmlElement("City")]
        [MaxLength(ValidationConstants.CityMaxLength)]
        [MinLength(ValidationConstants.CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [XmlElement("Country")]
        [MaxLength(ValidationConstants.CountryMaxLength)]
        [MinLength(ValidationConstants.CountryMinLength)]
        public string Country { get; set; } = null!;
    }
}

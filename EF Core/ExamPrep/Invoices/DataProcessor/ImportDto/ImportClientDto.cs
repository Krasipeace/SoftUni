namespace Invoices.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Data.Common;

    [XmlType("Client")]
    public class ImportClientDto
    {
        [Required]
        [XmlElement("Name")]
        [MaxLength(ValidationConstants.ClientNameMaxLength)]
        [MinLength(ValidationConstants.ClientNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("NumberVat")]
        [MaxLength(ValidationConstants.ClientNumberVatMaxLength)]
        [MinLength(ValidationConstants.ClientNumberVatMinLength)]
        public string NumberVat { get; set; } = null!;

        [XmlArray("Addresses")]
        public ImportAddressDto[] Addresses { get; set; } = null!;
    }
}

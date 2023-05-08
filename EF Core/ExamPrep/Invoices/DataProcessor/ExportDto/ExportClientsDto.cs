namespace Invoices.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Client")]
    public class ExportClientsDto
    {
        [XmlElement("ClientName")]
        public string Name { get; set; } = null!;

        [XmlElement("VatNumber")]
        public string NumberVat { get; set; } = null!;

        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }

        [XmlArray("Invoices")]
        public ExportInvoicesDto[] Invoices { get; set; } = null!;
    }
}

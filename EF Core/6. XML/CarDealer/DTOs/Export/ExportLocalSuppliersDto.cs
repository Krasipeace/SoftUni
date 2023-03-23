using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("supplier")]
public class ExportLocalSuppliersDto
{
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("parts-count")]

}

namespace CarDealer.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Customer")]
public class ImportCustomerDto
{
    [XmlElement("name")]
    public string Name { get; set; } 

    [XmlElement("birthDate")]
    public string BirthDate { get; set; } 

    [XmlElement("isYoungDriver")]
    public bool IsYoungDriver { get; set; }
}
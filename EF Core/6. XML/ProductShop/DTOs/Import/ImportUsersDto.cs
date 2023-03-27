namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("User")]
public class ImportUsersDto
{
    [XmlElement("firstname")]
    public string FirstName { get; set; } = null!;

    [XmlElement("lastname")]
    public string LastName { get; set; } = null!;

    [XmlElement("age")]
    public int? Age { get; set; }
}

namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("User")]
public class UserInfo
{
    [XmlElement("firstName")] 
    public string FirstName { get; set; } = null!;

    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;

    [XmlElement("age")]
    public int? Age { get; set; }

    public SoldProductsCount? SoldProducts { get; set; }
}

[XmlType("Users")]
public class ExportUserCountDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public UserInfo[]? Users { get; set; }
}

[XmlType("SoldProducts")]
public class SoldProductsCount
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public ExportSoldProductsDto[]? Products { get; set; }
}
namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("CategoryProduct")]
public class ImportCategoriesProductsDto
{
    [XmlElement("CategoryId")]
    public int CategoryId { get; set; }

    [XmlElement("ProductId")]
    public int ProductId { get; set; }
}

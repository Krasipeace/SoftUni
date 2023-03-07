namespace ProductShop.DTOs.Import;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

[JsonObject]
public class ImportProducts
{
    [JsonProperty(nameof(Name))]
    [Required]
    public string Name { get; set; }

    [JsonProperty(nameof(Price))]
    public decimal Price { get; set; }

    [JsonProperty(nameof(SellerId))]
    public int SellerId { get; set; }

    [JsonProperty(nameof(BuyerId))]
    public int? BuyerId { get; set; } 
}

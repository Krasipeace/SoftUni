using Newtonsoft.Json;

namespace ProductShop.DTOs.Export;

[JsonObject]
public class ExportUsersandProducts
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("buyerFirstName")]
    public string BuyerFirstName { get; set; }

    [JsonProperty("buyerLastName")]
    public string BuyerLastName { get; set; }
}



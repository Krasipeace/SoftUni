using Newtonsoft.Json;

namespace ProductShop.DTOs.Import;

[JsonObject]
public class ImportCategoriesAndProducts
{
    [JsonProperty(nameof(CategoryId))]
    public int CategoryId { get; set; }

    [JsonProperty(nameof(ProductId))]
    public int ProductId { get; set; }
}

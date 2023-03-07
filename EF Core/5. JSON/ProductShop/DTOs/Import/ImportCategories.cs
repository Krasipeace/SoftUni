namespace ProductShop.DTOs.Import;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

[JsonObject]
public class ImportCategories
{
    [JsonProperty("name")]
    [Required]
    public string Name { get; set; }
}

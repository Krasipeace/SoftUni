using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.Import;

[JsonObject]
public class ImportCategories
{
    [JsonProperty("name")]
    [Required]
    public string Name { get; set; }
}

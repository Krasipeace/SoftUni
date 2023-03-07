namespace ProductShop.DTOs.Import;

using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;


[JsonObject]
public class ImportUsers
{
    [JsonProperty("firstname")]
    public string FirstName { get; set; }

    [JsonProperty("lastname")]
    [Required]
    public string LastName { get; set; }

    [JsonProperty("age")]
    public int? Age { get; set; }
}

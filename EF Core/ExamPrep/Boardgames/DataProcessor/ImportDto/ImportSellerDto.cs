namespace Boardgames.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    internal class ImportSellerDto
    {
        [JsonProperty(nameof(Name))]
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [JsonProperty(nameof(Address))]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; } = null!;

        [JsonProperty(nameof(Country))]
        [Required]
        public string Country { get; set; } = null!;

        [JsonProperty(nameof(Website))]
        [Required]
        [RegularExpression("^www\\.[a-zA-Z0-9-]+\\.[a-zA-Z]{3}$")]
        public string Website { get; set; } = null!;

        [JsonProperty(nameof(Boardgames))]
        public List<int> Boardgames { get; set; } = new List<int>();
    }
}

namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using P02_FootballBetting.Data.Common;

public class Country
{
    public Country()
    {
        this.Towns = new HashSet<Town>();
    }

    [Key]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.COUNTRY_NAME_MAX_LENGTH)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Town> Towns { get; set; }
}

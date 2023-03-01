namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Data.Common;

public class Town
{
    public Town()
    {
        this.Teams = new HashSet<Team>();
    }

    [Key]
    public int TownId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.TOWN_NAME_MAX_LENGTH)]
    public string Name { get; set; } = null!;

    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; }
}

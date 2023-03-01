namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using P02_FootballBetting.Data.Common;

public class User
{
    public User()
    {
        this.Bets = new HashSet<Bet>();
    }

    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.USER_USERNAME_MAX_LENGTH)]
    public string Username { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.USER_PASSWORD_MAX_LENGTH)]
    public string Password { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.USER_EMAIL_MAX_LENGTH)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.USER_NAME_MAX_LENGTH)]
    public string Name { get; set; } = null!;

    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
}

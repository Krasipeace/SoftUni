using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data.Models
{
    /// <summary>
    /// Application User
    /// </summary>
    public class ApplicationUser
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();

            Articles = new HashSet<Article>();
        }

        /// <summary>
        /// Identifier of User
        /// </summary>
        [Key]
        [Comment("Identifier of User")]
        public string Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [Required]
        [StringLength(20)]
        [Comment("Username")]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Email of user
        /// </summary>
        [Required]
        [StringLength(50)]
        [Comment("Email of user")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Password of user
        /// </summary>
        [Required]
        [StringLength(20)]
        [Comment("Password of user")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Security stamp
        /// </summary>
        [Required]
        [StringLength(256)]
        public string PasswordSalt { get; set; } = null!;

        /// <summary>
        /// Collection of articles
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
    }
}

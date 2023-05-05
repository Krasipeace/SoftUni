namespace Blog.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Blog.Common;

    /// <summary>
    /// ApplicationUser Model.
    /// </summary>
    public class ApplicationUser
    {
        /// <summary>
        /// Application User.
        /// </summary>
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Articles = new HashSet<Article>();
        }

        /// <summary>
        /// Gets or sets identifier of registered user.
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets username of registered user.
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.USERNAMEMAXLENGTH)]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets email of registered user.
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.EMAILMAXLENGTH)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets password of registered user.
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.PASSWORDMAXLENGTH)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Gets or sets encryption of password.
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.PASSWORDMAXLENGTH)]
        public string PasswordSalt { get; set; } = null!;

        /// <summary>
        /// Gets or sets collection of articles.
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
    }
}

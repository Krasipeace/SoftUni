namespace Blog.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Blog.Common;

    /// <summary>
    /// Genre Model.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Collection of genres.
        /// </summary>
        public Genre()
        {
            this.Articles = new HashSet<Article>();
        }

        /// <summary>
        /// Gets or sets identifier of Genre.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name of Genre.
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.GENRELENGTH)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets collection of articles.
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
    }
}

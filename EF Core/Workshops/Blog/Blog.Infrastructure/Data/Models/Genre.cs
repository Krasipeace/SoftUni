using System.ComponentModel.DataAnnotations;

namespace Blog.Infrastructure.Data.Models
{
    public class Genre
    {
        /// <summary>
        /// Genre/Category of Article
        /// </summary>
        public Genre()
        {
            Articles =  new HashSet<Article>();
        }

        /// <summary>
        /// Identifier of Genre/Category of Article
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of Genre/Category of Article
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of Articles
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
    }
}

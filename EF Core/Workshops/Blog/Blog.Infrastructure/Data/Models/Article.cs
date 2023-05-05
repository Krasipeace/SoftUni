using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data.Models
{
    /// <summary>
    /// Article
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Identifier of article
        /// </summary>
        [Key]
        [Comment("Identifier of article")]
        public int Id { get; set; }

        /// <summary>
        /// Title of article
        /// </summary>
        [Required]
        [StringLength(50)]
        [Comment("Title of article")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Content of article
        /// </summary>
        [Required]
        [StringLength(1500)]
        [Comment("Content of article")]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Date of creation
        /// </summary>
        [Required]
        [Comment("Date of creation")]
        public DateTime CreatedOn { get; set; } 

        /// <summary>
        /// Author of article
        /// </summary>
        [Required]
        [ForeignKey(nameof(Author))]
        [Comment("Author of article")]
        public string AuthorId { get; set; } = null!;
        public virtual ApplicationUser Author { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;
    }
}

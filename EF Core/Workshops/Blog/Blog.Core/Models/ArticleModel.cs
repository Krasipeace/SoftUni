using Blog.Infrastructure.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog.Core.Models
{
    public class ArticleModel
    {
        /// <summary>
        /// Identifier of article
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of article
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "This field '{0} 'is required and must be between {2} and {1} symbols!")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Content of article
        /// </summary>
        [Required]
        [StringLength(1500, MinimumLength = 50, ErrorMessage = "This field '{0}' is required and must be between {2} and {1} symbols")]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Date of creation
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field '{0}' is required!")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Author of article
        /// </summary>
        [Required]
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; } = null!;
        public virtual ApplicationUser Author { get; set; } = null!;

        /// <summary>
        /// Genre of article
        /// </summary>
        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;
    }
}

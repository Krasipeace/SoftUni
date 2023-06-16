using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Library.Constants;

using Microsoft.EntityFrameworkCore;

namespace Library.Data.Models
{
    [Comment("Books for the library")]
    public class Book
    {
        [Comment("Primary key for the book")]
        [Key]
        public int Id { get; set; }

        [Comment("Title of the book")]
        [Required]
        [MaxLength(DataConstants.BookTitleLength)]
        public string Title { get; set; } = null!;

        [Comment("Author of the book")]
        [Required]
        [MaxLength(DataConstants.BookAuthorLength)]
        public string Author { get; set; } = null!;

        [Comment("Description of the book")]
        [Required]
        [MaxLength(DataConstants.BookDescriptionLength)]
        public string Description { get; set; } = null!;

        [Comment("Image URL of the book")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Rating of the book")]
        [Required]
        public decimal Rating { get; set; } 

        [Comment("Category Id of the book")]
        [Required]
        public int CategoryId { get; set; } 

        [Comment("Category of the book")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public List<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}

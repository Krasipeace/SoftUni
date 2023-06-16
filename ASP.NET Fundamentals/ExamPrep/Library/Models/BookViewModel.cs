using Library.Constants;

using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.BookTitleMaxLength, MinimumLength = ValidationConstants.BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.BookAuthorMaxLength, MinimumLength = ValidationConstants.BookAuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        [StringLength(ValidationConstants.BookDescriptionMaxLength, MinimumLength = ValidationConstants.BookDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Range(0, int.MaxValue)]
        public int CategoryId { get; set; } 
    }
}

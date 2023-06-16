using Library.Constants;

using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class EditBookViewModel
    {
        [Required]
        [StringLength(ValidationConstants.BookTitleMaxLength, MinimumLength = ValidationConstants.BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.BookAuthorMaxLength, MinimumLength = ValidationConstants.BookAuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;

        [Required]
        public string Rating { get; set; } = null!;

        [Required]
        [StringLength(ValidationConstants.BookDescriptionMaxLength, MinimumLength = ValidationConstants.BookDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Range(0, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}

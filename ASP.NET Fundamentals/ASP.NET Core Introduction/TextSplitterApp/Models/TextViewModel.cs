using System.ComponentModel.DataAnnotations;

namespace TextSplitterApp.Models
{
    public class TextViewModel
    {
        [Required(ErrorMessage = "The Text field is required")]
        [StringLength(30, MinimumLength = 2)]
        public string Text { get; set; } = null!;

        public string SplitText { get; set; } = null!;
    }
}

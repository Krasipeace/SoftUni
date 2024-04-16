using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(2048)]
        [Comment("Set to max Url length string to 2048 as good practice.")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public List<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}

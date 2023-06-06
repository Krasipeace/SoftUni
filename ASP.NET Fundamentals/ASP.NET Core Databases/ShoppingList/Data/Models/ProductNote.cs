using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.Data.Models
{
    public class ProductNote
    {
        /// <summary>
        /// Id of the product note.
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Description of the product note.
        /// </summary>
        [StringLength(100)]
        public string Content { get; set; } = null!;
        
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;
    }
}

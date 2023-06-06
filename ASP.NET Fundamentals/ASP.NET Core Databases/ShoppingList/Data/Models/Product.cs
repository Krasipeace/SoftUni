using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Data.Models
{
    public class Product
    {
        /// <summary>
        /// Id of the product.
        /// </summary>
        [Required]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Collection of notes for the product.
        /// </summary>
        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}

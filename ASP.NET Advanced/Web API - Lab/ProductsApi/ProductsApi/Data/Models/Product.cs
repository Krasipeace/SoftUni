namespace ProductsApi.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataValidationConstants;

    /// <summary>
    /// Product model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id of Product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of Product
        /// </summary>
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of Product
        /// </summary>
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}

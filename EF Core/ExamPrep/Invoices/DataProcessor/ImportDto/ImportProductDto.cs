namespace Invoices.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common;
    using Data.Models.Enums;

    public class ImportProductDto
    {
        [Required]
        [MaxLength(ValidationConstants.ProductNameMaxLength)]
        [MinLength(ValidationConstants.ProductNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range((double)ValidationConstants.ProductPriceMinValue, (double)ValidationConstants.ProductPriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 4)]
        public CategoryType CategoryType { get; set; }

        public int[] Clients { get; set; } = null!;
    }
}

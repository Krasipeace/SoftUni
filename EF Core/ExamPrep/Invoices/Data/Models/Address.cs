using Invoices.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.StreetNameMaxLength)]
        public string StreetName { get; set; } = null!;

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public string PostCode { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.CityMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.CountryMaxLength)]
        public string Country { get; set; } = null!;

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}

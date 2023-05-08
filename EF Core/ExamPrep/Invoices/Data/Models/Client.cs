using Invoices.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Client
    {
        public Client()
        {
            Invoices = new HashSet<Invoice>();
            Addresses = new HashSet<Address>();
            ProductsClients = new HashSet<ProductClient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.ClientNumberVatMaxLength)]
        public string NumberVat { get; set; } = null!;

        public ICollection<Invoice> Invoices { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<ProductClient> ProductsClients { get; set; }
    }
}

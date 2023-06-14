using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Models
{
    [Comment("User books")]
    public class IdentityUserBook
    {
        [Comment("Id of the collector")]
        public string CollectorId { get; set; } = null!;

        [Comment("Collector")]
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;

        [Comment("Id of the book")]
        public int BookId { get; set; }

        [Comment("Book")]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
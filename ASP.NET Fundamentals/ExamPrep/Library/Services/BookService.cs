using Microsoft.EntityFrameworkCore;
using Library.Contracts;
using Library.Data;
using Library.Models;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await this.dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId)
        {
            return await dbContext.UsersBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new MineBookViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                })
                .ToListAsync();
        }
    }
}

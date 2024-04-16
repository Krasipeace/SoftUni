namespace Library.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Library.Contracts;
    using Library.Data;
    using Library.Data.Models;
    using Library.Models;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;
        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<DisplayBooksViewModel>> GetAllBooksAsync()
        {
            return await this.dbContext.Books.Select(b => new DisplayBooksViewModel
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

        public async Task<IEnumerable<DisplayBooksViewModel>> GetMineBooksAsync(string userId)
        {
            return await this.dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .Select(b => new DisplayBooksViewModel
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

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await this.dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Description = b.Description,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool bookExists = await this.dbContext.IdentityUserBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!bookExists)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id
                };

                await this.dbContext.IdentityUserBooks.AddAsync(userBook);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromCollectionAsync(string userId, BookViewModel bookToRemove)
        {
            var userBook = await this.dbContext.IdentityUserBooks
                    .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == bookToRemove.Id);

            if (userBook != null)
            {
                this.dbContext.IdentityUserBooks.Remove(userBook);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await this.dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            var model = new AddBookViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book bookToAdd = new Book
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Rating = decimal.Parse(model.Rating),
                Description = model.Description,
                CategoryId = model.CategoryId
            };

            await this.dbContext.Books.AddAsync(bookToAdd);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddBookViewModel?> GetBookByIdForEditAsync(int id)
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return await dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new AddBookViewModel
                {
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating.ToString(),
                    CategoryId = b.CategoryId,
                    Categories = categories
                })
                .FirstOrDefaultAsync();
        }

        public async Task EditBookAsync(AddBookViewModel model, int id)
        {
            var bookToEdit = await dbContext.Books.FindAsync(id);

            if (bookToEdit != null)
            {
                bookToEdit.Title = model.Title;
                bookToEdit.Author = model.Author;
                bookToEdit.ImageUrl = model.ImageUrl;
                bookToEdit.Rating = decimal.Parse(model.Rating);
                bookToEdit.Description = model.Description;
                bookToEdit.CategoryId = model.CategoryId;

                await dbContext.SaveChangesAsync();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Library.Contracts;
using Library.Data;
using Library.Models;
using Library.Data.Models;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = decimal.Parse(model.Rating)
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await dbContext.UsersBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id
                };

                await dbContext.UsersBooks.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task EditBookAsync(EditBookViewModel model, int id)
        {
            var book = await dbContext.Books.FindAsync(id);

            if (book != null)
            {
                book.Title = model.Title;
                book.Author = model.Author;
                book.ImageUrl = model.Url;
                book.Description = model.Description;
                book.CategoryId = model.CategoryId;
                book.Rating = decimal.Parse(model.Rating);

                await dbContext.SaveChangesAsync();
            }
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

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext
                .Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EditBookViewModel?> GetIdForEditBookAsync(int id)
        {
            var categories = dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return await dbContext.Books
                .Where(b => b.Id == id)
                .Select(b => new EditBookViewModel
                {
                    Title = b.Title,
                    Author = b.Author,
                    Url = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating.ToString(),
                    CategoryId = b.CategoryId,
                    Categories = categories
                })
                .FirstOrDefaultAsync();
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

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await dbContext.Categories
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

        public async Task RemoveBookFromCollectionAsync(string userId, BookViewModel book)
        {
            var userBook = await dbContext.UsersBooks
                    .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (userBook != null)
            {
                dbContext.UsersBooks.Remove(userBook);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

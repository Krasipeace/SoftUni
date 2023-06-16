using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId);

        Task AddBookToCollectionAsync(string userId, BookViewModel book);

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);

        Task<AddBookViewModel> GetNewAddBookModelAsync();

        Task AddBookAsync(AddBookViewModel model);
    }
}

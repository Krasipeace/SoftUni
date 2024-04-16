namespace Library.Contracts
{
    using Library.Models;

    public interface IBookService
    {
        Task<IEnumerable<DisplayBooksViewModel>> GetAllBooksAsync();

        Task<IEnumerable<DisplayBooksViewModel>> GetMineBooksAsync(string userId);

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task AddBookToCollectionAsync(string userId, BookViewModel book);

        Task RemoveBookFromCollectionAsync(string userId, BookViewModel bookToRemove);

        Task<AddBookViewModel> GetNewAddBookModelAsync();
        Task AddBookAsync(AddBookViewModel model);
        Task<AddBookViewModel?> GetBookByIdForEditAsync(int id);
        Task EditBookAsync(AddBookViewModel model, int id);
    }
}

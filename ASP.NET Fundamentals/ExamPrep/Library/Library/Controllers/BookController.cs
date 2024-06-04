namespace Library.Controllers
{
    using Library.Contracts;
    using Library.Models;

    using Microsoft.AspNetCore.Mvc;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await this.bookService.GetAllBooksAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await this.bookService.GetMineBooksAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var bookToAdd = await this.bookService.GetBookByIdAsync(id);
            if (bookService == null)
            {
                return RedirectToAction("All", "Book");
            }

            var userId = GetUserId();
            await this.bookService.AddBookToCollectionAsync(userId, bookToAdd);

            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var bookToRemove = await this.bookService.GetBookByIdAsync(id);
            if (bookToRemove == null)
            {
                return RedirectToAction("Mine", "Book");
            }

            var userId = GetUserId();
            await this.bookService.RemoveBookFromCollectionAsync(userId, bookToRemove);

            return RedirectToAction("Mine", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await bookService.GetNewAddBookModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            decimal rating;
            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be between 0.00 and 10.00!");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = GetUserId();
            await bookService.AddBookAsync(model);

            return RedirectToAction("All", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            AddBookViewModel? bookToEdit = await bookService.GetBookByIdForEditAsync(id);
            if (bookToEdit == null)
            {
                return RedirectToAction("All", "Book");
            }

            return View(bookToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddBookViewModel model)
        {
            decimal rating;
            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be between 0.00 and 10.00!");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.EditBookAsync(model, id);

            return RedirectToAction("All", "Book");
        }
    }
}

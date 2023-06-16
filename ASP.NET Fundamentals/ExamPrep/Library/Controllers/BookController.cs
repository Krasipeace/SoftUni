using Microsoft.AspNetCore.Mvc;
using Library.Contracts;
using Library.Models;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBooksAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await bookService.GetMineBooksAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();

            await bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = GetUserId();

            await bookService.RemoveBookFromCollectionAsync(userId, book);

            return RedirectToAction(nameof(Mine));
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
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0.0 and 10.0");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditBookViewModel? book = await bookService.GetIdForEditBookAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBookViewModel model)
        {
            decimal rating;
            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0.0 and 10.0");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.EditBookAsync(model, id);

            return RedirectToAction(nameof(All));
        }
    }
}

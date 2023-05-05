namespace Blog.Web.Controllers
{
    using System.Threading.Tasks;

    using Blog.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : Controller
    {
        private readonly IGenreService genreService;

        public ArticleController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ICollection<ListGenreArticleAddViewModel> genres = await this.genreService.GetAllAsync();
            var viewModel = new ArticleAddViewModel()
            {
                Genres = genres,
            };

            return View(viewModel);
        }
    }
}

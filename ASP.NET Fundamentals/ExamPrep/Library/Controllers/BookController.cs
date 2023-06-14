using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        public IActionResult All()
        {
            return View();
        }
    }
}

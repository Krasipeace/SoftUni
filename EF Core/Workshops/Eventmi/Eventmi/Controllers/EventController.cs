using Microsoft.AspNetCore.Mvc;

using Eventmi.Core.Contracts;
using Eventmi.Core.Models;

namespace Eventmi.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly ILogger logger;

        public EventController(IEventService _eventService, ILogger<EventController> _logger)
        {
            eventService = _eventService;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<EventModel> model = Enumerable.Empty<EventModel>();

            try
            {
                model = await eventService.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("EventController/Index", ex);

                ViewBag.ErrorMessage = "Unknown Error!";
            }

            return View("All", model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new EventModel()
            {
                Start = DateTime.Today,
                End = DateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EventModel model)
        {
            // Server-side data validation
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await eventService.AddAsync(model);
            }
            catch (Exception ex)
            {

                logger.LogError("EventController/Add", ex);

                ViewBag.ErrorMessage = "Unknown Error!";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new EventModel();

            try
            {
                model = await eventService.GetEventAsync(id);

                return View(model);
            }
            catch (ArgumentException aex)
            {
                ViewBag.ErrorMessage = aex.Message;
            }
            catch (Exception ex)
            {
                logger.LogError("EventController/Details", ex);
                ViewBag.ErrorMessage = "Unknown Error!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

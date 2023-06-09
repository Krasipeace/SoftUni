namespace TaskBoardApp.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;

    using TaskBoardApp.Data;
    using TaskBoardApp.Models;

    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public HomeController(TaskBoardAppDbContext context)
        {
            data = context;
        }

        public async Task<IActionResult> Index()
        {
            var taskBoards = data.Boards
                .Select(b => b.Name)
                .Distinct();

            var tasksCounts = new List<HomeBoardModel>();

            foreach (var boardName in taskBoards)
            {
                var tasksInBoard = data.Tasks
                    .Where(t => t.Board.Name == boardName)
                    .Count();
                tasksCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });
            }

            var userTasksCount = -1;

            if (User.Identity.IsAuthenticated)
            {
                var currUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTasksCount = data.Tasks
                    .Where(t => t.OwnerId == currUserId)
                    .Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = data.Tasks.Count(),
                BoardsWithTasksCount = tasksCounts,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }
    }
}
namespace TaskBoardApp.Models.Board
{
    using TaskBoardApp.Models.Task;

    public class BoardViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}

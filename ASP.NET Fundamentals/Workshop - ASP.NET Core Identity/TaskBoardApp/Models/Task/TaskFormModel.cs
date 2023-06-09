namespace TaskBoardApp.Models.Task
{
    using System.ComponentModel.DataAnnotations;
    using TaskBoardApp.Data;

    public class TaskFormModel
    {
        [Required]
        [StringLength(DataConstants.TaskTitleMaxLength, MinimumLength = DataConstants.TaskTitleMinLength, ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.TaskDescriptionMaxLength, MinimumLength = DataConstants.TaskDescriptionMinLength, ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
    }
}

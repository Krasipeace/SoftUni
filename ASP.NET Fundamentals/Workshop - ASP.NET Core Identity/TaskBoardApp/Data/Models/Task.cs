namespace TaskBoardApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class Task
    {
        /// <summary>
        /// Id of the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the task.
        /// </summary>
        [Required]
        [MaxLength(DataConstants.TaskTitleMaxLength)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Description of the task.
        /// </summary>
        [Required]
        [MaxLength(DataConstants.TaskDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Info about when task was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Foreign key of the board that the task is in.
        /// </summary>
        public int BoardId { get; set; }

        /// <summary>
        /// Collection of boards that the task is in.
        /// </summary>
        public Board? Board { get; set; }

        /// <summary>
        /// Foreign key of the user that created the task.
        /// </summary>
        public string OwnerId { get; set; } = null!;

        /// <summary>
        /// IdentityUser that created the task.
        /// </summary>
        public IdentityUser User { get; set; } = null!;
    }
}

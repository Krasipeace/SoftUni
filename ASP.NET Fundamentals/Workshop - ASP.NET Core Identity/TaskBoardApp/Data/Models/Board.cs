namespace TaskBoardApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Board
    {
        /// <summary>
        /// Id of the board.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Name of the board.
        /// </summary>
        [Required]
        [MaxLength(DataConstants.BoardNameMaxLength)]
        public string Name { get; init; } = null!;

        /// <summary>
        /// Collection of tasks in the board.
        /// </summary>
        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}

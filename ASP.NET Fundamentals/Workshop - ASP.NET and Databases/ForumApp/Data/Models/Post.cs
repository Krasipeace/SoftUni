namespace ForumApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        /// <summary>
        /// Id of the post.
        /// </summary>
        [Key]
        public int Id { get; init; }

        /// <summary>
        /// Title of the post.
        /// </summary>
        [Required]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Content of the post.
        /// </summary>
        [Required]
        [MaxLength(DataConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}

﻿namespace Blog.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Blog.Common;

    /// <summary>
    /// Article Model.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Gets or sets identifier of article.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets title of article.
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.TITLEMAXLENGTH)]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets or sets content of article.
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.CONTENTMAXLENGTH)]
        public string Content { get; set; } = null!;

        /// <summary>
        /// Gets or sets created on date of article.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets relation to author.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; } = null!;

        public virtual ApplicationUser Author { get; set; }

        /// <summary>
        /// Gets or sets relation to genre.
        /// </summary>
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}

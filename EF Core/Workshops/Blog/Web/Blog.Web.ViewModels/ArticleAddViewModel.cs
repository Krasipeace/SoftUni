﻿namespace Blog.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Blog.Common;
    using Blog.Web.ViewModels.Genres;

    public class ArticleAddViewModel
    {
        [Required]
        [MinLength(ValidationConstants.TITLEMINLENGTH)]
        [MaxLength(ValidationConstants.TITLEMAXLENGTH)]
        public string Title { get; set; }

        [Required]
        [MinLength(ValidationConstants.CONTENTMINLENGTH)]
        [MaxLength(ValidationConstants.CONTENTMAXLENGTH)]
        public string Content { get; set; }

        public int GenreId { get; set; } 

        public ICollection<ListGenreArticleAddViewModel> Genres { get; set; }
    }
}

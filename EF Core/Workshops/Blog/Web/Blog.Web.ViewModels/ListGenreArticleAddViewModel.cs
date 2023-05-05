﻿namespace Blog.Web.ViewModels.Genres
{
    using Blog.Data.Models;
    using Blog.Services.Mapping;

    public class ListGenreArticleAddViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

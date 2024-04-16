﻿namespace Library.Models
{
    public class DisplayBooksViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal? Rating { get; set; }

        public string? Description { get; set; }

        public string Category { get; set; } = null!;
    }
}

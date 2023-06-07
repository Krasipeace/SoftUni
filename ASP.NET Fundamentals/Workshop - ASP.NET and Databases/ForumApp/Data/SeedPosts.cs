namespace ForumApp.Data
{
    using Models;

    public class SeedPosts
    {
        public Post FirstPost { get; set; } = null!;

        public Post SecondPost { get; set; } = null!;

        public Post ThirdPost { get; set; } = null!;

        public void SeedPost()
        {
            FirstPost = new Post()
            {
                Id = 1,
                Title = "First Post",
                Content = "First Post Content CRUD operations in MVC. Its so much fun!"
            };

            SecondPost = new Post()
            {
                Id = 2,
                Title = "Second Post",
                Content = "Second Post Content CRUD operations in MVC. Its so interesting"
            };

            ThirdPost = new Post()
            {
                Id = 3,
                Title = "Third Post",
                Content = "Third Post Content CRUD operations in MVC. Stay tuned!"
            };
        }
    }
}

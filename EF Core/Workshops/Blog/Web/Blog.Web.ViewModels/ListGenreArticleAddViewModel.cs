namespace Blog.Web.ViewModels
{
    using Blog.Data.Models;
    using Blog.Services.Mapping;

    public class ListGenreArticleAddViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

namespace ForumApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ForumApp.Data;
    using ForumApp.Models.Post;
    using ForumApp.Data.Models;

    public class PostController : Controller
    {
        private readonly ForumAppDbContext data;

        public PostController(ForumAppDbContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var posts = await data.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            var postToAdd = new Post()
            {
                Title = post.Title,
                Content = post.Content
            };

            await data.Posts.AddAsync(postToAdd);
            await data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var postToEdit = await data.Posts.FindAsync(id);

            if (postToEdit == null)
            {
                return NotFound();
            }

            return View(new PostFormModel()
            {
                Title = postToEdit.Title,
                Content = postToEdit.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostFormModel model)
        {
            var postToEdit = await data.Posts.FindAsync(id);

            if (postToEdit == null)
            {
                return NotFound();
            }

            postToEdit.Title = model.Title;
            postToEdit.Content = model.Content;

            await data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var postToDelete = await data.Posts.FindAsync(id);

            if (postToDelete == null)
            {
                return NotFound();
            }

            data.Posts.Remove(postToDelete);
            await data.SaveChangesAsync();

            return RedirectToAction("All");
        }
    }
}

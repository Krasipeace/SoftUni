namespace ForumApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ForumApp.Data;
    using ForumApp.Models.Post;
    using ForumApp.Data.Models;
    using System.Security.Cryptography.X509Certificates;

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
        public async Task<IActionResult> Add(PostViewModel post)
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

            data.Posts.Add(postToAdd);
            await data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await data.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            var postToEdit = new PostViewModel()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };

            return View(postToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostViewModel post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            var postToEdit = await data.Posts.FindAsync(id);

            if (postToEdit == null)
            {
                return NotFound();
            }

            postToEdit.Title = post.Title;
            postToEdit.Content = post.Content;

            await data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var postToDelete = data.Posts.Find(id);

            if (postToDelete == null)
            {
                return NotFound();
            }

            data.Posts.Remove(postToDelete);
            data.SaveChanges();

            return RedirectToAction("All");
        }
    }
}

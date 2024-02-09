using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; 
using NCA_FA3.Data;
using NCA_FA3.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using NCA_FA3.Controllers;

namespace YourNamespace.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<BlogController> _logger; // Add logger

        public BlogController(ApplicationDbContext context, ILogger<BlogController> logger)
        {
            _db = context;
            _logger = logger; // Inject logger
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
            try
            {
                var posts = await _db.BlogPosts.ToListAsync();
                _logger.LogInformation("Retrieved {Count} blog posts from the database.", posts.Count);
                return View(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving blog posts.");
                throw; // Re-throw the exception
            }
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student blogPost)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.BlogPosts.Add(blogPost);
                    await _db.SaveChangesAsync();
                    _logger.LogInformation("Created a new blog post with ID {PostID}.", blogPost.PostID); // Log creation
                    return RedirectToAction("Index");
                }
                return View(blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a blog post.");
                throw; // Re-throw the exception
            }
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                Student blogPost = await _db.BlogPosts.FindAsync(id);
                if (blogPost == null)
                {
                    return NotFound();
                }
                return View(blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing a blog post.");
                throw; // Re-throw the exception
            }
            
        }

        // GET: Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                Student blogPost = await _db.BlogPosts.FindAsync(id);
                if (blogPost == null)
                {
                    return NotFound();
                }
                return View(blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing a blog post.");
                throw; // Re-throw the exception
            }
        }

        // POST: Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student blogPost)
        {
            try
            {
                if (id != blogPost.PostID)
                {
                    return BadRequest();
                }

                if (ModelState.IsValid)
                {
                    _db.Entry(blogPost).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    _logger.LogInformation("Edited blog post with ID {PostID}.", blogPost.PostID); // Log edit
                    return RedirectToAction("Index"); // Ensure you are redirecting to the "Index" action.
                }
                return View(blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing a blog post.");
                throw; // Re-throw the exception
            }
        }

        // GET: Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                Student blogPost = await _db.BlogPosts.FindAsync(id);
                if (blogPost == null)
                {
                    return NotFound();
                }
                return View(blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving blog post for deletion.");
                throw; // Re-throw the exception
            }
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Student blogPost = await _db.BlogPosts.FindAsync(id);
                if (blogPost == null)
                {
                    return NotFound();
                }

                _db.BlogPosts.Remove(blogPost);
                await _db.SaveChangesAsync();
                _logger.LogInformation("Deleted blog post with ID {PostID}.", blogPost.PostID); // Log deletion
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a blog post.");
                throw; // Re-throw the exception
            }
        }
    }
}
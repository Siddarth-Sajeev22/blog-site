using BlogSite.Interfaces;
using BlogSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogPostsService _service;

        public AdminController(IBlogPostsService service)
        {
            _service = service;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            var posts = await _service.GetAllAsync();
            return View(posts);
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var post = await _service.GetByIdAsync(id);
            if (post == null) return NotFound();
            return View(post);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPost post)
        {
            if (!ModelState.IsValid) return View(post);
            await _service.CreateAsync(post);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _service.GetByIdAsync(id);
            if (post == null) return NotFound();
            return View(post);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogPost post)
        {
            if (id != post.Id) return BadRequest();
            if (!ModelState.IsValid) return View(post);

            var ok = await _service.UpdateAsync(id, post);
            if (!ok) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _service.GetByIdAsync(id);
            if (post == null) return NotFound();
            return View(post);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}

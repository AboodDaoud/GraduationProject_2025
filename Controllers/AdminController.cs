using GraduationProject.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Data;

namespace GraduationProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly AppDbContext _context;

        public AdminController(ILogger<AdminController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pendingBlogs = _context.Blogs.ToList();
            return View(pendingBlogs);
        }
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                blog.IsApproved = true;
                _context.Blogs.Update(blog);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index","Admin");
        }
    }
}

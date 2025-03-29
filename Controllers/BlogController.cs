using GraduationProject.Models;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace GraduationProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly AppDbContext _context;

        public BlogController(ILogger<BlogController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var blogs = _context.Blogs.Where(p => p.IsApproved == true).ToList();
            return View(blogs);
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "يجب عليك تسجيل الدخول لإضافة مدونة.";
                return RedirectToAction("Login", "Login");
            }

            blog.UserId = userId;
            blog.CategoryID = 4;
            blog.Quote = "test";
            blog.Button_Text = "test";
            blog.Button_Url = "test";
            blog.IsApproved = false;

            // Remove properties that are causing validation issues
            ModelState.Remove("Category");
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            ModelState.Remove("Quote");
            ModelState.Remove("Button_Text");
            ModelState.Remove("Button_Url");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                foreach (var error in errors)
                {
                    Console.WriteLine(error);  // Debugging
                }

                ViewBag.Errors = errors;  // Show errors in the view
            }

            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

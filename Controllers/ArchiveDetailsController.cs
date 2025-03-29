using GraduationProject.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Globalization;
using System.Security.Claims;

namespace GraduationProject.Controllers
{
    public class ArchiveDetailsController : Controller
    {
        private readonly ILogger<ArchiveDetailsController> _logger;
        private readonly AppDbContext _context;

        public ArchiveDetailsController(ILogger<ArchiveDetailsController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? cityId, int? categoryId, string sortBy, int fromYear = 1900, int toYear = 3000, int archiveType = 0)
        {
            if (toYear == null) toYear = DateTime.Now.Year;
            if (fromYear == null) fromYear = 1900;

            ViewBag.ArchiveType = categoryId;
            ViewBag.CategoryId = categoryId;
            ViewBag.City = cityId;
            ViewBag.FromYear = fromYear;
            ViewBag.ToYear = toYear;
            ViewBag.SortBy = sortBy;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "يجب عليك تسجيل الدخول لتتمكن من رؤية البيانات المؤرشفة.";
                return RedirectToAction("Login", "Login");
            }

            // Fetch categories and cities from the database
            var categories = _context.Categories
                .Select(c => new { c.CategoryId, c.CategoryName })
                .ToList();
            var cities = _context.Cities
                .Select(c => new { c.City_Id, c.City_Name })
                .ToList();

            ViewBag.Categories = categories;
            ViewBag.Cities = cities;

            var mediaList = _context.MediaArchive
                .Include(m => m.Category).Include(c => c.City).ToList();

            // Filtering
            if (cityId.HasValue && cityId > 0)
                mediaList = mediaList.Where(m => m.CityId == cityId).ToList();

            if (categoryId.HasValue && categoryId > 0)
                mediaList = mediaList.Where(m => m.CategoryId == categoryId).ToList();

            mediaList = mediaList.Where(m => m.Year >= fromYear && m.Year <= toYear).ToList();

            // Sorting
            mediaList = sortBy == "oldest"
                ? mediaList.OrderBy(m => m.Year).ToList()
                : mediaList.OrderByDescending(m => m.Year).ToList();

            // Handle no data case
            if (!mediaList.Any())
            {
                ViewBag.Message = "لا توجد عناصر متاحة في الأرشيف.";
                return View(new List<MediaArchive>());
            }

            return View(mediaList);
        }
        public IActionResult Filter(int? city, int? categoryId, string? sortBy, int? fromYear = 1900, int? toYear = 3000, int? archiveType = 0)
        {
            toYear ??= DateTime.Now.Year; // Set to current year if null
            fromYear ??= 1900;

            // Fetch categories and cities from the database
            var categories = _context.Categories
                .Select(c => new { c.CategoryId, c.CategoryName })
                .ToList();
            var cities = _context.Cities
                .Select(c => new { c.City_Id, c.City_Name })
                .ToList();

            // Store filter values in ViewBag to persist in UI
            ViewBag.Categories = categories;
            ViewBag.Cities = cities;
            ViewBag.ArchiveType = categoryId;
            ViewBag.CategoryId = categoryId;
            ViewBag.City = city;
            ViewBag.FromYear = fromYear;
            ViewBag.ToYear = toYear;
            ViewBag.SortBy = sortBy;

            var mediaList = _context.MediaArchive.Include(m => m.Category)
                .Include(m => m.City)
                .AsQueryable();

            // Apply city filter
            if (city.HasValue && city > 0)
                mediaList = mediaList.Where(m => m.CityId == city);

            // Apply category filter correctly
            if (categoryId.HasValue && categoryId > 0)
                mediaList = mediaList.Where(m => m.CategoryId == categoryId);

            // Apply year range filter
            mediaList = mediaList.Where(m => m.Year >= fromYear && m.Year <= toYear);

            // Apply sorting
            mediaList = sortBy == "oldest"
                ? mediaList.OrderBy(m => m.Year)
                : mediaList.OrderByDescending(m => m.Year);

            return PartialView("_FilteredMediaList", mediaList.ToList());
        }
    }
}

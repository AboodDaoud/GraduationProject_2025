using GraduationProject.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace GraduationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var cities = _context.Cities.ToList();
            var videos = _context.Videos.ToList();
            var slides = _context.Slides.ToList();
            var blogs = _context.Blogs.Where(b => b.IsApproved == true).ToList();


            var viewModel = new HomeViewModel
            {
                Cities = cities,
                Videos = videos,
                Slides = slides,
                Blogs = blogs
            };

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
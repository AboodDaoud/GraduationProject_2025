using GraduationProject.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace GraduationProject.Controllers
{
    public class VirtualToursController : Controller
    {
        private readonly ILogger<VirtualToursController> _logger;
        private readonly AppDbContext _context;

        public VirtualToursController(ILogger<VirtualToursController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<City>? cities = _context.Cities.Where(c => c.VirtualTourLink != null).ToList();
            foreach (var city in cities)
            {
                city.VirtualTourLink = ConvertToEmbedUrl(city.VirtualTourLink);
            }
            return View(cities);
        }
        private string ConvertToEmbedUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return "";

            Uri uri = new Uri(url);
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            string videoId = query["v"];

            return !string.IsNullOrEmpty(videoId) ? $"https://www.youtube.com/embed/{videoId}" : url;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

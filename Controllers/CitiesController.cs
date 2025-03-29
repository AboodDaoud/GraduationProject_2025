using GraduationProject.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace GraduationProject.Controllers
{
    public class CitiesController : Controller
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly AppDbContext _context;

        public CitiesController(ILogger<CitiesController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var cities = _context.Cities.ToList();
            var villages = _context.Villages.ToList();
            var viewModel = new CityViewModel
            {
                Cities = cities,
                Villages = villages
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetByCity(int cityId)
        {
            var villages = _context.Villages
                                   .Where(v => v.City_ID == cityId)
                                   .Select(v => new
                                   {
                                       village_ID = v.Village_ID,
                                       village_Name = v.Village_Name,
                                       village_ImageUrl = v.Village_ImageUrl,
                                       village_Description = v.Village_Description,
                                       village_Highlights = v.Village_Highlights
                                   })
                                   .ToList();

            return Json(villages);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
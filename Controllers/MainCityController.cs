using GraduationProject.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    public class MainCityController : Controller
    {
        private readonly ILogger<MainCityController> _logger;
        private readonly AppDbContext _context;
        public MainCityController(ILogger<MainCityController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int cityId)
        {
            var city = _context.Cities
                .Include(c => c.Landmarks) // Include related landmarks
                .FirstOrDefault(c => c.City_Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var selectedCity = new SelectedCityViewModel
            {
                City_Id = city.City_Id,
                City_Name = city.City_Name,
                City_Description = city.City_Description,
                City_ImageUrl = city.City_ImageUrl,
                City_Area = city.City_Area,
                City_Population = city.City_Population,
                Detailed_Information = city.Detailed_Information,
                Landmarks = city.Landmarks.Select(l => new LandmarkViewModel
                {
                    Landmark_Id = l.Landmark_Id,
                    Landmark_Name = l.Landmark_Name,
                    Landmark_Description = l.Landmark_Description,
                    Year_Built = l.Year_Built,
                    Importance = l.Importance,
                    Image_Path = l.Image_Path
                }).ToList()
            };

            return View(selectedCity);
        }



    }
}

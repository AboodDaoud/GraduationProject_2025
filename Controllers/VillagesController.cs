using GraduationProject.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Controllers
{
    public class VillagesController : Controller
    {
        private readonly ILogger<VillagesController> _logger;
        private readonly AppDbContext _context;

        public VillagesController(ILogger<VillagesController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        //public IActionResult index(int? cityId)
        //{
        //    var villages = _context.Villages.AsQueryable();

        //    if (cityId.HasValue)
        //    {
        //        villages = villages.Where(v => v.City_ID == cityId.Value);
        //    }

        //    var villageList = villages.Select(v => new
        //    {
        //        v.Village_ID,
        //        v.Village_Name,
        //        v.Village_ImageUrl,
        //        v.Village_Description,
        //        v.Village_Highlights
        //    }).ToList();

        //    ViewBag.Villages = villageList;
        //    return View();
        //}
        public IActionResult Index(int? cityId)
        {
            var citiesWithVillages = _context.Cities
                .Where(city => !cityId.HasValue || city.City_Id == cityId.Value) // Filter by cityId if provided
                .Select(city => new
                {
                    CityName = city.City_Name,
                    Villages = city.Villages.Select(v => new
                    {
                        v.Village_ID,
                        v.Village_Name,
                        v.Village_ImageUrl,
                        v.Village_Description,
                        v.Village_Highlights
                    }).ToList()
                })
                .ToList();

            ViewBag.CitiesWithVillages = citiesWithVillages;

            return View();
        }
    }
}

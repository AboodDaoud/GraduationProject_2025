using GraduationProject.Models;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace GraduationProject.Controllers
{
    public class ArchivesController : Controller
    {
        private readonly ILogger<ArchivesController> _logger;
        private readonly AppDbContext _context;
        public ArchivesController(ILogger<ArchivesController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

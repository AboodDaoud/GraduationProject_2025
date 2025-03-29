using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class WhoweController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

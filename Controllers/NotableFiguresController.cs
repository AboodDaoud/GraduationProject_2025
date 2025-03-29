using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class NotableFiguresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

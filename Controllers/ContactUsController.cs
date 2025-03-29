using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

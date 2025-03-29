using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

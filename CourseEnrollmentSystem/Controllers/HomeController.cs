using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View(); // This will return Privacy.cshtml
        }
    }
}

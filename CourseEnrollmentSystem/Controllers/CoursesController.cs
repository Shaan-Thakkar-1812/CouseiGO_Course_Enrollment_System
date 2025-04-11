using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
   [Authorize]
    public class EnrollmentController : Controller
    {
        public IActionResult MyCourses()
        {
            return View();
        }
    }
}

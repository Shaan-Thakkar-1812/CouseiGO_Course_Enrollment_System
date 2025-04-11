using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnrollmentSystem.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}

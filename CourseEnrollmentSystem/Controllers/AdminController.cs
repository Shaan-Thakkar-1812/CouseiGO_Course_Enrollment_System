using CourseEnrollmentSystem.Data;
using CourseEnrollmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CourseEnrollmentSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // ✅ Admin Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var users = await _userManager.Users.ToListAsync();
            int totalStudents = 0;

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Student"))
                {
                    totalStudents++;
                }
            }

            var totalCourses = await _context.Courses.CountAsync();
            var totalEnrollments = await _context.Enrollments.CountAsync();

            ViewBag.TotalStudents = totalStudents;
            ViewBag.TotalCourses = totalCourses;
            ViewBag.TotalEnrollments = totalEnrollments;

            return View("Dashboard"); // Make sure Dashboard.cshtml exists
        }

        // You can later add: ViewUsers, ManageCourses, etc.
    }
}

using CourseEnrollmentSystem.Data;
using CourseEnrollmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CourseEnrollmentSystem.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Dashboard()
        {
            var userId = _userManager.GetUserId(User); // Logged-in Identity user ID

            // ❗ Assumes Visitor table has IdentityUserId column
            var visitor = await _context.Visitors
                .FirstOrDefaultAsync(v => v.IdentityUserId == userId);

            if (visitor == null)
            {
                // Create a Visitor record automatically if missing (optional)
                visitor = new Visitor
                {
                    IdentityUserId = userId!,
                    Name = User.Identity?.Name ?? "Unnamed",
                    Email = User.Identity?.Name ?? "no-email@example.com"
                };

                _context.Visitors.Add(visitor);
                await _context.SaveChangesAsync();
            }

            var enrollments = await _context.Enrollments
                .Include(e => e.Course)
                .Where(e => e.VisitorId == visitor.Id)
                .ToListAsync();

            return View(enrollments); // View must exist in Views/Student/Dashboard.cshtml
        }
    }
}

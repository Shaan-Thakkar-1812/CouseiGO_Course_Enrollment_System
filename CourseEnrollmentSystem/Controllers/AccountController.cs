using CourseEnrollmentSystem.Models;
using CourseEnrollmentSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CourseEnrollmentSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // ✅ Register (GET)
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // ✅ Register (POST)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var email = model.Email.ToLower();

            var user = new ApplicationUser
            {
                FullName = model.FullName,
                UserName = email,
                Email = email,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Assign selected role
                if (!string.IsNullOrEmpty(model.Role))
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
                    if (!roleResult.Succeeded)
                    {
                        foreach (var error in roleResult.Errors)
                            ModelState.AddModelError("", error.Description);

                        return View(model);
                    }
                }

                await _signInManager.SignInAsync(user, isPersistent: false);

                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                    return RedirectToAction("Dashboard", "Admin");
                else if (roles.Contains("Student"))
                    return RedirectToAction("Dashboard", "Student");
                else
                    return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // ✅ Login (GET)
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // ✅ Login (POST)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email.ToLower());

            if (user == null || string.IsNullOrEmpty(user.UserName))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                    return RedirectToAction("Dashboard", "Admin");
                else if (roles.Contains("Student"))
                    return RedirectToAction("Dashboard", "Student");
                else
                    return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        // ✅ Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

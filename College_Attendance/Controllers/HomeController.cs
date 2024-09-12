using College_Attendance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                // Non-authenticated users
                return RedirectToAction("ListDates", "AttendanceEdit");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (await _userManager.IsInRoleAsync(user, "admin"))
                {
                    // Redirect to Admin Home
                    return RedirectToAction("Index", "AdminHome");
                }
                else if (await _userManager.IsInRoleAsync(user, "student"))
                {
                    // Redirect to Student Dashboard
                    return RedirectToAction("Index", "StudentDashboard");
                }
            }

            // Default fallback, if role is not recognized or user is not authenticated (unlikely to hit this point)
            return RedirectToAction("ListDates", "EditAttendance");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using College_Attendance.Data;
using College_Attendance.Models;
using College_Attendance.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace College_Attendance.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAttendanceData _attendanceData;

        public StudentDashboardController(UserManager<IdentityUser> userManager, IAttendanceData attendanceData)
        {
            _userManager = userManager;
            _attendanceData = attendanceData;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            // Get the currently logged-in user
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Error", "Home");
            }

            // Retrieve the student ID from the Student table using the email
            var student = _attendanceData.GetStudentByEmail(user.Email);

            if (student == null)
            {
                return RedirectToAction("Error", "Home");
            }

            // Retrieve the attendance records for the student
            var attendanceRecords = _attendanceData.GetAttendanceByStudentId(student.StudentId);

            List<StudentDashboardViewModel> viewModel=new List<StudentDashboardViewModel>();
            // Prepare the view model
            foreach (var attendance in attendanceRecords)
            {
                viewModel.Add(new StudentDashboardViewModel { 
                    DateTime=attendance.Date,
                    IsPresent=attendance.IsPresent,
                    SubjectName=_attendanceData.GetSubjectNameByID(attendance.SubjectId),
                });
            }
            IEnumerable<StudentDashboardViewModel> viewModelList = viewModel;
            // Pass the view model to the view
            return View(viewModelList);
        }
    }
}

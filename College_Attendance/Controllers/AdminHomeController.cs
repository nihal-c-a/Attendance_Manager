using College_Attendance.Models;
using College_Attendance.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace College_Attendance.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly ILogger<AdminHomeController> _logger;
        private readonly IAttendanceData _attendanceData;

        public AdminHomeController(ILogger<AdminHomeController> logger, IAttendanceData attendanceData)
        {
            _logger = logger;
            _attendanceData = attendanceData;
        }

        [Authorize]
        public IActionResult Index()
        {
            var allAttendance = _attendanceData.GetAttendance();

            // Calculate average attendance per day of the week
            var averageAttendancePerDay = allAttendance
                .GroupBy(a => a.Date.DayOfWeek)
                .Select(g => (int)((double)g.Count(a => a.IsPresent) / g.Count() * 100)) // Ratio of present to total
                .ToList();

            // Calculate average attendance per subject
            var averageAttendancePerSubject = allAttendance
                .GroupBy(a => a.SubjectId)
                .Select(g => (int)((double)g.Count(a => a.IsPresent) / g.Count() * 100)) // Ratio of present to total
                .ToList();

            var subjects = allAttendance
                .GroupBy(a => a.SubjectId)
                .Select(g => _attendanceData.GetSubjectNameByID(g.Key))
                .ToList();

            var viewModel = new AttendanceSummaryViewModel
            {
                AverageAttendancePerDay = averageAttendancePerDay,
                AverageAttendancePerSubject = averageAttendancePerSubject,
                Subjects = subjects
            };

            return View(viewModel);
        }

       
    }
}

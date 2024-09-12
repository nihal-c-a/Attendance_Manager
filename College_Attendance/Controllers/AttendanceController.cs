using College_Attendance.Data;
using College_Attendance.Models;
using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace College_Attendance.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceData _attendanceData;
        private readonly ApplicationDbContext _context;

        public AttendanceController(IAttendanceData attendanceData, ApplicationDbContext context)
        {
            _attendanceData = attendanceData;
            _context = context;
        }

        // GET: Attendance/MarkAttendance
        [HttpGet]
        public IActionResult MarkAttendance()
        {
            var model = new MarkAttendanceViewModel
            {
                Date = DateTime.Now,
                Subjects = _context.Subjects.ToList(),
                Students = _context.Students
                    .Select(s => new MarkAttendanceViewModel.StudentAttendance
                    {
                        StudentId = s.StudentId,
                        StudentName = s.FirstName + " " + s.LastName,
                        IsPresent = true
                    })
                    .ToList()
            };

            return View(model);
        }

        // POST: Attendance/MarkAttendance
        [HttpPost]
        public IActionResult MarkAttendance(MarkAttendanceViewModel model)
        {
            foreach (var student in model.Students)
            {
                var existingAttendance = _context.Attendances
                    .FirstOrDefault(a => a.StudentId == student.StudentId && a.SubjectId == model.SubjectId && a.Date.Date == model.Date.Date);

                if (existingAttendance != null)
                {
                    existingAttendance.IsPresent = student.IsPresent;
                    _context.Update(existingAttendance);
                }
                else
                {
                    var attendance = new Attendance
                    {
                        StudentId = student.StudentId,
                        SubjectId = model.SubjectId,
                        Date = model.Date,
                        IsPresent = student.IsPresent
                    };
                    _context.Add(attendance);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        // GET: /Attendance/FetchAttendance
        public IActionResult FetchAttendance()
        {
            var model = new MarkAttendanceViewModel
            {
                Subjects = _context.Subjects.ToList(),
                
            };
            model.Students = _context.Students
                    .Select(s => new MarkAttendanceViewModel.StudentAttendance
                    {
                        StudentId = s.StudentId,
                        StudentName = s.FirstName + " " + s.LastName,
                        IsPresent = true
                    })
                    .ToList();

            return View(model);
        }

        // POST: /Attendance/FetchAttendance
        [HttpPost]
        public IActionResult FetchAttendance(MarkAttendanceViewModel model)
        {
            // Fetch attendance records based on the selected date and subject
            var attendanceRecords = _context.Attendances
                .Where(a => a.Date.Date == model.Date)
                .Select(a => new AttendanceRecordViewModel
                {
                    Date = a.Date,
                    SubjectName = _context.Subjects
                        .Where(s => s.SubjectId == a.SubjectId)
                        .Select(s => s.SubjectName)
                        .FirstOrDefault(),
                    StudentName = _context.Students
                        .Where(s => s.StudentId == a.StudentId)
                        .Select(s => s.FirstName + " " + s.LastName)
                        .FirstOrDefault(),
                    IsPresent = a.IsPresent
                })
                .ToList();

            // Pass the data to the AttendanceRecords view
            return View("AttendanceRecords", attendanceRecords);
        }
        [HttpPost]
        public IActionResult FetchAttendanceOnSubject(MarkAttendanceViewModel model)
        {
            // Fetch attendance records based on the selected date and subject
            var attendanceRecords = _context.Attendances
                .Where(a => a.SubjectId == model.SubjectId)
                .Select(a => new AttendanceRecordViewModel
                {
                    Date = a.Date,
                    SubjectName = _context.Subjects
                        .Where(s => s.SubjectId == a.SubjectId)
                        .Select(s => s.SubjectName)
                        .FirstOrDefault(),
                    StudentName = _context.Students
                        .Where(s => s.StudentId == a.StudentId)
                        .Select(s => s.FirstName + " " + s.LastName)
                        .FirstOrDefault(),
                    IsPresent = a.IsPresent
                })
                .ToList();

            // Pass the data to the AttendanceRecords view
            return View("AttendanceRecords", attendanceRecords);
        }

        [HttpPost]
        public IActionResult FetchAttendanceOnStudent(MarkAttendanceViewModel model)
        {
            // Fetch attendance records based on the selected date and subject
            int sid = model.Students[0].StudentId;
            var attendanceRecords = _context.Attendances
                .Where(a => a.StudentId == sid)
                .Select(a => new AttendanceRecordViewModel
                {
                    Date = a.Date,
                    SubjectName = _context.Subjects
                        .Where(s => s.SubjectId == a.SubjectId)
                        .Select(s => s.SubjectName)
                        .FirstOrDefault(),
                    StudentName = _context.Students
                        .Where(s => s.StudentId == a.StudentId)
                        .Select(s => s.FirstName + " " + s.LastName)
                        .FirstOrDefault(),
                    IsPresent = a.IsPresent
                })
                .ToList();

            // Pass the data to the AttendanceRecords view
            return View("AttendanceRecords", attendanceRecords);
        }
    }
}

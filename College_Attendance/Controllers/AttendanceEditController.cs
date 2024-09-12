using College_Attendance.Data;
using College_Attendance.Models;
using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace College_Attendance.Controllers
{
    public class AttendanceEditController : Controller
    {
        private readonly IAttendanceData _attendanceData;

        public AttendanceEditController(IAttendanceData attendanceData)
        {
            _attendanceData = attendanceData;
        }

        // Action to display the form to select a date
        public IActionResult ListDates(bool? isreadonly = false)
        {
            var dates = _attendanceData.GetAttendance()
                                .Select(a => a.Date.Date)
                                .Distinct()
                                .ToList();
            TempData["IsReadOnly"] = isreadonly;
            return View(dates);
        }

        // Action to list all unique subjects for a selected date
        public IActionResult SelectSubjects(DateTime date)
        {
            var attendance = _attendanceData.GetAttendanceByDate(date);
            var subjectIds = attendance.Select(a => a.SubjectId).Distinct().ToList();
            var subjects = subjectIds.Select(subjectId => new Subject
            {
                SubjectId = subjectId,
                SubjectName = _attendanceData.GetSubjectNameByID(subjectId)
            }).ToList();

            var viewModel = new MarkAttendanceViewModel
            {
                Date = date,
                Subjects = subjects
            };

            return View(viewModel);
        }

        // Action to display students for attendance editing
        public IActionResult EditAttendance(DateTime date, int subjectId,string subjectName )
        {
            var attendance = _attendanceData.GetAttendanceForDateAndTime(date, subjectId);
            var students = attendance.Select(a => new MarkAttendanceViewModel.StudentAttendance
            {
                AttendanceId = a.AttendanceId,
                StudentId = a.StudentId,
                StudentName = _attendanceData.GetStudentNameByID(a.StudentId),
                IsPresent = a.IsPresent
            }).ToList();

            List<Subject> SubjectList=new List<Subject>();
            SubjectList.Add(new Subject { SubjectName = _attendanceData.GetSubjectNameByID(subjectId) });
            var viewModel = new MarkAttendanceViewModel
            {
                Date = date,
                SubjectId = subjectId,
                Subjects=SubjectList,
                Students = students
            };

            return View(viewModel);
        }

        // Action to save the edited attendance
        [HttpPost]
        public IActionResult SaveAttendance(MarkAttendanceViewModel model)
        {
            foreach (var student in model.Students)
            {
                _attendanceData.EditAttendance(student.AttendanceId, student.IsPresent);
            }

            return RedirectToAction("Index","AdminHome");
        }
    }
}

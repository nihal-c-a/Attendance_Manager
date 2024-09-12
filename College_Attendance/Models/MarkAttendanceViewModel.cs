using College_Attendance.Models.Class;
using System.ComponentModel.DataAnnotations;
using College_Attendance.Data;

namespace College_Attendance.Models
{
    public class MarkAttendanceViewModel
    {
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }
     
        public List<StudentAttendance> Students { get; set; } 
        public List<Subject> Subjects { get; set; } 

        public class StudentAttendance
        {
            public int AttendanceId { get; set; }
            public int StudentId { get; set; }
            public string StudentName { get; set; } = String.Empty;
            public bool IsPresent { get; set; }
        }
    }
}

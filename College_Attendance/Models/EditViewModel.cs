using College_Attendance.Models.Class;

namespace College_Attendance.Models
{
    public class EditViewModel
    {
        public int AttendanceId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public bool IsPresent { get; set; }
        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set;} 
    }
}

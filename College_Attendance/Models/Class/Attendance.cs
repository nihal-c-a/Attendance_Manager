using System.ComponentModel.DataAnnotations;

namespace College_Attendance.Models.Class
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool IsPresent { get; set; }

        // Foreign key for Student
        public int StudentId { get; set; }

        // Foreign key for Subject
        public int SubjectId { get; set; }
    }
}

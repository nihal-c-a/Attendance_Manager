using System.ComponentModel.DataAnnotations;

namespace College_Attendance.Models.Class
{
    public class Subject
    {

        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string SubjectName { get; set; }

        // Navigation property for Attendance
        public ICollection<Attendance> Attendances { get; set; }
    }
}

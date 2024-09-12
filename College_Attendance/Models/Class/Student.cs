using System.ComponentModel.DataAnnotations;

namespace College_Attendance.Models.Class
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

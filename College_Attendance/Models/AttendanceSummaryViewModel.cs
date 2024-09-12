namespace College_Attendance.Models
{
    public class AttendanceSummaryViewModel
    {
        public List<int> AverageAttendancePerDay { get; set; }
        public List<int> AverageAttendancePerSubject { get; set; }
        public List<string> Subjects { get; set; }
    }
}

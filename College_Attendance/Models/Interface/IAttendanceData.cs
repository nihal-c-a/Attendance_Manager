using College_Attendance.Models.Class;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace College_Attendance.Models.Interface
{
    public interface IAttendanceData
    {
        void MarkAttendance(int studentId, int subjectId, DateTime date, bool isPresent);
        IEnumerable<Attendance> GetAttendanceRecordsByStudent(int studentId);

        IEnumerable<Attendance> GetAttendanceRecordsBySubject(int subjectId);
        IEnumerable<Attendance> GetAttendanceByDate(DateTime date);
        public string GetStudentNameByID(int studentId);
        public string GetSubjectNameByID(int SubjectId);
        public List<Attendance> GetAttendanceForDateAndTime(DateTime date,int subjectId);
        public List<Attendance> GetAttendance();
        public void EditAttendance(int AttendanceId, bool isPresent);
        Student GetStudentByEmail(string email);
        IEnumerable<Attendance> GetAttendanceByStudentId(int studentId);

        public string GetSubjectNameById(int subjectId);

    }
}

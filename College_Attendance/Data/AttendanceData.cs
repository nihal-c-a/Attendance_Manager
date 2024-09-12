using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;


namespace College_Attendance.Data
{
    public class AttendanceData : IAttendanceData
    {
        private readonly ApplicationDbContext _context;

        public AttendanceData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void MarkAttendance(int studentId, int subjectId, DateTime date, bool isPresent)
        {
            var attendance = new Attendance
            {
                StudentId = studentId,
                SubjectId = subjectId,
                Date = date,
                IsPresent = true,
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }

        public List<Attendance> GetAttendance()
        {
            return _context.Attendances.ToList();
        }


        public IEnumerable<Attendance> GetAttendanceRecordsByStudent(int studentId)
        {
            return _context.Attendances
                           .Where(a => a.StudentId == studentId)
                           .ToList();
        }

        public IEnumerable<Attendance> GetAttendanceRecordsBySubject(int subjectId)
        {
            return _context.Attendances
                           .Where(a => a.SubjectId == subjectId)
                           .ToList();
        }

        public IEnumerable<Attendance> GetAttendanceByDate(DateTime date)
        {
            return _context.Attendances
                           .Where(a => a.Date.Date == date.Date)
                           .ToList();
        }

        public void EditAttendance(int AttendanceId, bool isPresent)
        {
            var attendance = _context.Attendances
                                      .FirstOrDefault(a => a.AttendanceId == AttendanceId);

            if (attendance != null)
            {
                attendance.IsPresent = isPresent;
                _context.Attendances.Update(attendance);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Attendance record not found.");
            }
        }
        public string GetStudentNameByID(int studentId)
        {
            var student = _context.Students
                      .FirstOrDefault(s => s.StudentId == studentId);
            string name = student.FirstName + " " + student.LastName;
            return name;
        }
        public string GetSubjectNameByID(int SubjectId)
        {
            var subject = _context.Subjects
                      .FirstOrDefault(s => s.SubjectId == SubjectId);
            string name = subject.SubjectName;
            return name;
        }
        public List<Attendance> GetAttendanceForDateAndTime(DateTime date, int subjectId)
        {
            return _context.Attendances
                            .Where(a => a.Date.Date == date.Date && a.SubjectId==subjectId)
                            .ToList();
        }
        public string GetSubjectNameById(int subjectId)
        {
            return _context.Subjects.Where(s=>s.SubjectId==subjectId).Select(s=>s.SubjectName).FirstOrDefault();
        }
        public Student GetStudentByEmail(string email)
        {
            return _context.Students.FirstOrDefault(s => s.Email == email);
        }

        public IEnumerable<Attendance> GetAttendanceByStudentId(int studentId)
        {
            return _context.Attendances.Where(a => a.StudentId == studentId).ToList();
        }






    }
}

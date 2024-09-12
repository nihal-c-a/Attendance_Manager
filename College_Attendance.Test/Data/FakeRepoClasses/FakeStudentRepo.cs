using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_Attendance.Test.Data.FakeRepoClasses
{
    public class FakeStudentRepo : IStudent
    {
        private readonly List<Student> _students;

        public FakeStudentRepo(List<Student> students)
        {
            _students = students;
        }

        public Task<List<Student>> GetAllStudentsAsync()
        {
            return Task.FromResult(_students);
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            return Task.FromResult(_students.FirstOrDefault(s => s.StudentId == id));
        }

        public async Task AddStudentAsync(Student student)
        {
            // Check if a student with the same email already exists in the fake repository
            var existingStudent = _students.FirstOrDefault(s => s.Email == student.Email);
            if (existingStudent != null)
            {
                throw new InvalidOperationException("A student with the same email already exists.");
            }

            _students.Add(student);
            await Task.CompletedTask; // Simulate async behavior
        }

        public Task UpdateStudentAsync(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Email = student.Email;
                existingStudent.Password = student.Password;
            }
            return Task.CompletedTask;
        }

        public Task DeleteStudentAsync(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                _students.Remove(student);
            }
            return Task.CompletedTask;
        }
    }
}

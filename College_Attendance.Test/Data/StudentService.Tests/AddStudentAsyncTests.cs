using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using College_Attendance.Test.Data.FakeRepoClasses;

namespace College_Attendance.Test.Data.StudentService.Tests
{
    public class AddStudentAsyncTests
    {
        private readonly IStudent _studentService;
        private readonly List<Student> _students;

        public AddStudentAsyncTests()
        {
            _students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "Password123" }
            };

            _studentService = new FakeStudentRepo(_students);
        }

        [Fact]
        public async Task ShouldAddStudent()
        {
            var newStudent = new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = "Password123" };
            await _studentService.AddStudentAsync(newStudent);

            var student = _students.FirstOrDefault(s => s.StudentId == 2);
            Assert.NotNull(student);
        }

        [Fact]
        public async Task ShouldIncreaseStudentCount()
        {
            var newStudent = new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = "Password123" };
            await _studentService.AddStudentAsync(newStudent);

            Assert.Equal(2, _students.Count);
        }

        [Fact]
        public async Task ShouldNotAddDuplicateStudent()
        {
            var duplicateStudent = new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "Password123" };
            await Assert.ThrowsAsync<System.InvalidOperationException>(() => _studentService.AddStudentAsync(duplicateStudent));
        }

        // Data-driven test using Theory and InlineData
        [Theory]
        [InlineData(2, "Alice", "Johnson", "alice.johnson@example.com", "Password123")]
        [InlineData(3, "Bob", "Brown", "bob.brown@example.com", "Password123")]
        [InlineData(4, "Charlie", "Davis", "charlie.davis@example.com", "Password123")]
        public async Task ShouldAddMultipleStudents(int studentId, string firstName, string lastName, string email, string password)
        {
            // Arrange
            var newStudent = new Student
            {
                StudentId = studentId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            // Act
            await _studentService.AddStudentAsync(newStudent);

            // Assert
            var student = _students.FirstOrDefault(s => s.StudentId == studentId);
            Assert.NotNull(student);
            Assert.Equal(firstName, student.FirstName);
            Assert.Equal(lastName, student.LastName);
            Assert.Equal(email, student.Email);
        }
    }
}

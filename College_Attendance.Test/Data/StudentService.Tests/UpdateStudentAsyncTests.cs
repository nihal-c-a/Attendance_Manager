using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using College_Attendance.Test.Data.FakeRepoClasses;

namespace College_Attendance.Test.Data.StudentService.Tests
{
    public class UpdateStudentAsyncTests
    {
        private readonly IStudent _studentService;
        private readonly List<Student> _students;

        public UpdateStudentAsyncTests()
        {
            _students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "Password123" }
            };

            _studentService = new FakeStudentRepo(_students);
        }

        [Fact]
        public async Task ShouldUpdateStudentDetails()
        {
            var updatedStudent = new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "NewPassword123" };
            await _studentService.UpdateStudentAsync(updatedStudent);

            var student = _students.FirstOrDefault(s => s.StudentId == 1);
            Assert.NotNull(student);
            Assert.Equal("NewPassword123", student.Password);
        }

        
        [Fact]
        public async Task ShouldNotUpdateNonExistentStudent()
        {
            // Arrange
            var nonExistentStudent = new Student
            {
                StudentId = 99,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                Password = "Password123"
            };

            // Act
            await _studentService.UpdateStudentAsync(nonExistentStudent);

            // Assert
            // Ensure the student list remains unchanged
            Assert.Equal(1, _students.Count); // Assuming the initial count is 1 in your repo
            var student = _students.FirstOrDefault(s => s.StudentId == 99);
            Assert.Null(student);
        }

        [Fact]
        public async Task ShouldMaintainStudentCount_WhenUpdating()
        {
            var updatedStudent = new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "NewPassword123" };
            await _studentService.UpdateStudentAsync(updatedStudent);

            Assert.Equal(1, _students.Count);
        }
    }
}

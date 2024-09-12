using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using College_Attendance.Test.Data.FakeRepoClasses;

namespace College_Attendance.Test.Data.StudentService.Tests
{
    public class DeleteStudentAsyncTests
    {
        private readonly IStudent _studentService;
        private readonly List<Student> _students;

        public DeleteStudentAsyncTests()
        {
            _students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "Password123" },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = "Password123" }
            };

            _studentService = new FakeStudentRepo(_students);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task ShouldDeleteExistingStudent(int studentId)
        {
            // Act
            await _studentService.DeleteStudentAsync(studentId);

            // Assert
            var student = _students.FirstOrDefault(s => s.StudentId == studentId);
            Assert.Null(student);
        }

        [Fact]
        public async Task ShouldReduceStudentCountAfterDeletion()
        {
            // Arrange
            int initialCount = _students.Count;

            // Act
            await _studentService.DeleteStudentAsync(1);

            // Assert
            Assert.Equal(initialCount - 1, _students.Count);
        }

        [Fact]
        public async Task ShouldNotDeleteNonExistentStudent()
        {
            // Arrange
            int initialCount = _students.Count;

            // Act
            await _studentService.DeleteStudentAsync(99);

            // Assert
            Assert.Equal(initialCount, _students.Count); // Verify count remains unchanged
        }

        [Fact]
        public async Task ShouldHandleMultipleSequentialDeletions()
        {
            // Act
            await _studentService.DeleteStudentAsync(1);
            await _studentService.DeleteStudentAsync(2);

            // Assert
            Assert.Empty(_students); // Verify all students have been deleted
        }

      
    }
}

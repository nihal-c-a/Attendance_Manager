using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using College_Attendance.Test.Data.FakeRepoClasses;

namespace College_Attendance.Test.Data.StudentService.Tests
{
    public class GetStudentByIdAsyncTests
    {
        private readonly IStudent _studentService;

        public GetStudentByIdAsyncTests()
        {
            var students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "Password123" },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = "Password123" }
            };

            _studentService = new FakeStudentRepo(students);
        }

        [Fact]
        public async Task ShouldReturnCorrectStudent()
        {
            var student = await _studentService.GetStudentByIdAsync(1);
            Assert.NotNull(student);
            Assert.Equal("John", student.FirstName);
        }

        [Fact]
        public async Task ShouldReturnNull_WhenStudentDoesNotExist()
        {
            var student = await _studentService.GetStudentByIdAsync(99);
            Assert.Null(student);
        }

        [Fact]
        public async Task ShouldReturnCorrectStudentById()
        {
            var student = await _studentService.GetStudentByIdAsync(2);
            Assert.NotNull(student);
            Assert.Equal("Jane", student.FirstName);
        }
    }
}

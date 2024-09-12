using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using College_Attendance.Test.Data.FakeRepoClasses;

namespace College_Attendance.Test.Data.StudentService.Tests
{
    public class GetAllStudentsAsyncTests
    {
        private readonly IStudent _studentService;

        public GetAllStudentsAsyncTests()
        {
            var students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "Password123" },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Password = "Password123" }
            };

            _studentService = new FakeStudentRepo(students);
        }

        [Fact]
        public async Task ShouldReturnAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            Assert.Equal(2, students.Count);
        }

        [Fact]
        public async Task ShouldReturnEmptyList_WhenNoStudents()
        {
            var emptyRepo = new FakeStudentRepo(new List<Student>());
            var students = await emptyRepo.GetAllStudentsAsync();
            Assert.Empty(students);
        }

        [Fact]
        public async Task ShouldReturnCorrectStudentDetails()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var student = students.FirstOrDefault(s => s.StudentId == 1);
            Assert.NotNull(student);
            Assert.Equal("John", student.FirstName);
            Assert.Equal("Doe", student.LastName);
        }

        [Fact]
        public async Task ShouldMaintainOrderOfStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            Assert.Equal(1, students[0].StudentId);
            Assert.Equal(2, students[1].StudentId);
        }

        [Fact]
        public async Task ShouldHandleLargeDataset()
        {
            var largeRepo = new FakeStudentRepo(Enumerable.Range(1, 1000).Select(i =>
                new Student { StudentId = i, FirstName = $"FirstName{i}", LastName = $"LastName{i}", Email = $"email{i}@example.com", Password = "Password123" }).ToList());

            var students = await largeRepo.GetAllStudentsAsync();
            Assert.Equal(1000, students.Count);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        public async Task ShouldHandleDifferentSizesOfDatasets(int studentCount)
        {
            var repo = new FakeStudentRepo(Enumerable.Range(1, studentCount).Select(i =>
                new Student { StudentId = i, FirstName = $"FirstName{i}", LastName = $"LastName{i}", Email = $"email{i}@example.com", Password = "Password123" }).ToList());

            var students = await repo.GetAllStudentsAsync();
            Assert.Equal(studentCount, students.Count);
        }
    }
}

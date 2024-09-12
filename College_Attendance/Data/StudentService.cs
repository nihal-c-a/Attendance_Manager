using College_Attendance.Models.Class;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using College_Attendance.Models.Interface;

namespace College_Attendance.Data
{
    public class StudentService : IStudent
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public StudentService(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            // Check if a student with the same email already exists
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.Email == student.Email);
            if (existingStudent != null)
            {
                throw new InvalidOperationException("A student with the same email already exists.");
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var user = new IdentityUser { UserName = student.Email, Email = student.Email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, student.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "student");
            }
        }


        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            var user = await _userManager.FindByEmailAsync(student.Email);
            if (user != null)
            {
                user.UserName = student.Email;
                user.Email = student.Email;

                if (!string.IsNullOrEmpty(student.Password))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, token, student.Password);
                }

                await _userManager.UpdateAsync(user);
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                var user = await _userManager.FindByEmailAsync(student.Email);
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
            }
        }
    }
}

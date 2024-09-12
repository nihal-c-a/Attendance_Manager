using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using College_Attendance.Models.Class;
using College_Attendance.Models.Interface;
using Microsoft.AspNetCore.Authorization;

public class StudentController : Controller
{
    private readonly IStudent _studentService;

    public StudentController(IStudent studentService)
    {
        _studentService = studentService;
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return View(students);
    }
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student model)
    {
        if (ModelState.IsValid)
        {
            await _studentService.AddStudentAsync(model);
            return RedirectToAction("Index", "Student");
        }

        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            await _studentService.UpdateStudentAsync(student);
            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
    [Authorize(Roles = "Admin")]
    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Student model)
    {
         await _studentService.DeleteStudentAsync(model.StudentId);
        return RedirectToAction("Index", "Student");
    }


    public async Task<IActionResult> Details(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
}

using Microsoft.AspNetCore.Mvc;
using Courses.BL.Services;
using Courses.DAL.Models.Dtos;

namespace Courses.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentDto student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updatedStudent = await _studentService.UpdateStudentAsync(id, student);
                if (updatedStudent == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Details), new { id = updatedStudent.StudentId });
            }
            return View(student);
        }
    }
}

using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Repository;
using LibraryManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<StudentModel> studentList = new List<StudentModel>();

            try
            {
                studentList = _studentService.GetAllStudents();
            } catch (Exception ex) {
                TempData["errorMessage"] = ex.Message;
                    
            }
            
            return View(studentList);
        }
    }
}

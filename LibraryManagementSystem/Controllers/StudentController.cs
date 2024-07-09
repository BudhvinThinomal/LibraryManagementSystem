using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            GetAllStudentRequest getAllStudentRequest = new GetAllStudentRequest();

            try
            {
                studentList = _studentService.GetAllStudents(getAllStudentRequest);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            return View(studentList);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudentForm(CreateStudentRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _studentService.CreateStudent(request);
                    if (result.ErrorMessage == null)
                    {
                        TempData["successMessage"] = "Student Registered Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Failed to Register the Student. Please Recheck the Student Details";
                        return View("CreateStudent");
                    }
                }
                else
                {
                    TempData["errorMessage"] = "Student Details Not Valid";
                    return View("CreateStudent");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");

            }
        }

        [HttpGet]
        public IActionResult TerminateStudent(int id)
        {
            StudentModel student = new StudentModel();

            try
            {
                student = _studentService.GetStudent(id);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            if (student == null)
            {
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult Terminate(int StudentID)
        {
            try
            {
                TerminateStudentRequest terminateStudentRequest = new TerminateStudentRequest() {
                    StudentId = StudentID,
                    TerminatedDate = DateTime.Now,
                };
                
                var result = _studentService.TerminateStudent(terminateStudentRequest);
                if (result.ErrorMessage == null)
                {
                    TempData["successMessage"] = "Student Terminated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Failed to Terminate the Student.";
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");

            }
        }

        [HttpGet]
        public IActionResult ViewStudent(int id)
        {
            StudentModel student = new StudentModel();

            try
            {
                student = _studentService.GetStudent(id);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            if (student == null)
            {
                return RedirectToAction("Index");
            }

            return View(student);
        }


        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            StudentModel student = new StudentModel();

            try
            {
                student = _studentService.GetStudent(id);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            if (student == null)
            {
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudentForm(StudentModel request)
        {
            try
            {
                EditStudentRequest editStudentRequest = new EditStudentRequest() { 
                    StudentId= request.StudentID,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Address = request.Address,
                    Telephone = request.Telephone,
                };
               
                var result = _studentService.EditStudent(editStudentRequest);
                if (result.ErrorMessage == null)
                {
                    TempData["successMessage"] = "Student Edited Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Failed to Edit the Student. Please Recheck the Student Details";
                    return View("EditStudent");
                }
                
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");

            }
        }

    }
}

using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class IssueBookController : Controller
    {
        private readonly IssueBookService _issueBookService;
        private readonly BookService _bookService;
        private readonly StudentService _studentService;

        public IssueBookController(IssueBookService issueBookService, StudentService studentService, BookService bookService)
        {
            _issueBookService = issueBookService;
            _studentService = studentService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(GetSelectList());
        }

        [HttpPost]
        public IActionResult CreateIssueBook(IssueBookView issueBookView)
        {
            try
            {
                issueBookView.CreateIssueBookRequest.IssueDate = DateTime.Now;

                var result = _issueBookService.CreateIssueBook(issueBookView.CreateIssueBookRequest);
                if (result.ErrorMessage == null)
                {
                    TempData["successMessage"] = "Book Issued Successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["errorMessage"] = "Failed to issue the Book. Please Recheck the Issue Details";
                    return View("Index", GetSelectList());
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View("Index", GetSelectList());
            }


        }

        private IssueBookView GetSelectList()
        {
            List<StudentModel> studentList = new List<StudentModel>();
            GetAllStudentRequest getAllStudentRequest = new GetAllStudentRequest()
            {
                IssueDate = DateTime.Now
            };

            try
            {
                studentList = _studentService.GetAllStudents(getAllStudentRequest);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }

            List<BookModel> bookList = new List<BookModel>();
            GetAllBookRequest getAllBookRequest = new GetAllBookRequest()
            {
                IssueDate = DateTime.Now
            };

            try
            {
                bookList = _bookService.GetAllBooks(getAllBookRequest);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;

            }

            IssueBookView issueBookView = new IssueBookView();

            issueBookView.SelectBookList = new List<SelectListItem>();
            foreach (BookModel book in bookList)
            {
                issueBookView.SelectBookList.Add(new SelectListItem() { Text = book.Title, Value = book.ReferenceNumber.ToString() });
            }


            issueBookView.SelectStudentList = new List<SelectListItem>();
            foreach (StudentModel student in studentList)
            {
                issueBookView.SelectStudentList.Add(new SelectListItem() { Text = student.StudentName, Value = student.StudentID.ToString() });
            }

            return issueBookView;
        }

    }
}

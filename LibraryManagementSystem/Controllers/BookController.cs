using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBook(CreateBookRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _bookService.CreateBook(request);
                    if (result.ErrorMessage == null)
                    {
                        TempData["successMessage"] = "Book Registered Successfully";
                        return RedirectToAction("Index", "Home");
                    }
                    else {
                        TempData["errorMessage"] = "Failed to Register the Book. Please Recheck the Book Details";
                        return View("Index");
                    }
                }
                else
                {
                    TempData["errorMessage"] = "Book Details Not Valid";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View("Index");
            }

            
        }
    }
}

using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookService _bookService;

        public HomeController(ILogger<HomeController> logger, BookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index(GetAllBookRequest request)
        {
            List<BookModel> bookList = new List<BookModel>();

            try
            {
                bookList = _bookService.GetAllBooks(request);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;

            }

            return View(bookList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
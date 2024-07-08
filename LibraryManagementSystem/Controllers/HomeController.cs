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
        public IActionResult Index(string searchString)
        {
            List<BookModel> bookList = new List<BookModel>();
            GetAllBookRequest getAllBookRequest = new GetAllBookRequest()
            {
                Parameter = searchString
            };

            try
            {
                bookList = _bookService.GetAllBooks(getAllBookRequest);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;

            }

            HomeView homeView = new HomeView() { 
                BookList = bookList,
                GetAllBookRequest = getAllBookRequest
            };

            return View(homeView);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
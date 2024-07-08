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

        public JsonResult GetFilteredBooks()
        {
            List<BookModel> bookList = new List<BookModel>();

            System.Threading.Thread.Sleep(2000);
            int draw = Convert.ToInt32(Request.Query["draw"]);

            // Page Index
            int page = Convert.ToInt32(Request.Query["start"]);

            // Page Limit
            int limit = Convert.ToInt32(Request.Query["length"]);

            // Getting Sort Column Name
            int sortColumnIdx = Convert.ToInt32(Request.Query["order[0][column]"]);
            string sortColumnName = Request.Query["columns[" + sortColumnIdx + "][name]"];

            // Sort Column Direction  
            string sortColumnDirection = Request.Query["order[0][dir]"];

            // Search Value
            string parameter = Request.Query["search[value]"].FirstOrDefault()?.Trim();

            try
            {
                GetAllBookRequest request = new GetAllBookRequest()
                {
                    Parameter = null,
                    IssueDate = null,
                    Page = null,
                    Limit = null
                };

                bookList = _bookService.GetAllBooks(request);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;

            }

            if (bookList != null && bookList.Count > 0)
            {
                // Total count matching search criteria 
                int recordsFilteredCount =
                    bookList
                    .Where(a => a.Title.Contains(parameter) || a.Author.Contains(parameter))
                    .Count();

                // Filtered & Sorted & Paged data to be sent from server to view
                List<BookModel> filteredData = null;
                if (sortColumnDirection == "asc")
                {
                    filteredData =
                       bookList
                        .Where(a => a.Title.Contains(parameter) || a.Author.Contains(parameter))
                        .OrderBy(x => x.GetType().GetProperty(sortColumnName).GetValue(x))
                        .ToList<BookModel>();
                }
                else
                {
                    filteredData =
                       bookList
                       .Where(a => a.Title.Contains(parameter) || a.Author.Contains(parameter))
                       .OrderByDescending(x => x.GetType().GetProperty(sortColumnName).GetValue(x))
                       .ToList<BookModel>();
                }

                return Json(
                        new
                        {
                            data = bookList,
                            draw = Request.Query["draw"],
                            recordsFiltered = recordsFilteredCount,
                            recordsTotal = bookList[0]?.TotalRows | 0
                        }
                    );
            } 
            else
            {
                return Json(
                        new
                        {
                            data = bookList,
                            draw = Request.Query["draw"],
                            recordsFiltered = 0,
                            recordsTotal =  0
                        }
                    );
            } 
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
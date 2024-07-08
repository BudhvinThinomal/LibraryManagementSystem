using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class IssueBookController : Controller
    {
        private readonly IssueBookService _issueBookService;

        public IssueBookController(IssueBookService issueBookService)
        {
            _issueBookService = issueBookService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateIssueBook(CreateIssueBookRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _issueBookService.CreateIssueBook(request);
                    if (result.ErrorMessage == null)
                    {
                        TempData["successMessage"] = "Book Issued Successfully";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Failed to issue the Book. Please Recheck the Issue Details";
                        return View("Index");
                    }
                }
                else
                {
                    TempData["errorMessage"] = "Issue Details Not Valid";
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

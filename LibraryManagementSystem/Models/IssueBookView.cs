using LibraryManagementSystem.Models.Request;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Models
{
    public class IssueBookView
    {
        public List<SelectListItem> SelectBookList { get; set; }
        public List<SelectListItem> SelectStudentList {  get; set; }
        public CreateIssueBookRequest CreateIssueBookRequest { get; set; }
    }
}

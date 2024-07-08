using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;

namespace LibraryManagementSystem.Models
{
    public class HomeView
    {
        public List<BookModel> BookList { get; set; }
        public GetAllBookRequest GetAllBookRequest { get; set; }
    }
}

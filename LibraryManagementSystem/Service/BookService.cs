using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Models.Response;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Service
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //Get All Books
        public List<BookModel> GetAllBooks()
        {
            try
            {
                return _bookRepository.GetAllBooks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Register Book
        public CreateBookResponse CreateBook(CreateBookRequest request)
        {
            try
            {
                return _bookRepository.CreateBook(request);
            }
            catch (Exception ex)
            {
                return new CreateBookResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}

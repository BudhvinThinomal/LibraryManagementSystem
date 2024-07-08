using LibraryManagementSystem.Models.Entities;
using LibraryManagementSystem.Models.Request;
using LibraryManagementSystem.Models.Response;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Service
{
    public class IssueBookService
    {
        private readonly IssueBookRepository _issueBookRepository;

        public IssueBookService(IssueBookRepository issueBookRepository)
        {
            _issueBookRepository = issueBookRepository;
        }

        //Issue Book
        public CreateIssueBookResponse CreateIssueBook(CreateIssueBookRequest request)
        {
            try
            {
                return _issueBookRepository.CreateIssueBook(request);
            }
            catch (Exception ex)
            {
                return new CreateIssueBookResponse()
                {
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}

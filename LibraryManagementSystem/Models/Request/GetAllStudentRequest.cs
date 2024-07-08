namespace LibraryManagementSystem.Models.Request
{
    public class GetAllStudentRequest
    {
        public DateTime? IssueDate { get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }
    }
}

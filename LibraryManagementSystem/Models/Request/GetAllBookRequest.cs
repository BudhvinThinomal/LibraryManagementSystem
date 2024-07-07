namespace LibraryManagementSystem.Models.Request
{
    public class GetAllBookRequest
    {
        public string? Parameter { get; set; }
        public DateTime? IssueDate { get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }
    }
}

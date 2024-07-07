namespace LibraryManagementSystem.Models.Entities
{
    public class BookModel
    {
        public int ReferenceNumber { get; set; }
        public string Title { get; set; }
        public string Publication { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int? StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int TotalRows { get; set; }
    }
}

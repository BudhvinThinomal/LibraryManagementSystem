namespace LibraryManagementSystem.Models.Entities
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime TerminatedDate { get; set; }
        public int TotalRows { get; set; }
    }
}

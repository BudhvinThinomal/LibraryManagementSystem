using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.Request
{
    public class StudentRequest
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        [Required]
        public DateTime RegisteredDate { get; set; }
        public DateTime TerminatedDate { get; set; }
    }
}

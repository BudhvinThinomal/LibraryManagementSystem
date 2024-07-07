using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.Request
{
    public class CreateStudentRequest
    {
        [DisplayName("First Name")]
        [Required]
        public required string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Email { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        [DisplayName("Registered Date")]
        [Required]
        public DateTime RegisteredDate { get; set; }
        [DisplayName("Terminated Date")]
        public DateTime? TerminatedDate { get; set; }
    }
}

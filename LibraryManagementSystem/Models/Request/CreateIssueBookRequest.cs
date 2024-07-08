using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryManagementSystem.Models.Request
{
    public class CreateIssueBookRequest
    {
        [DisplayName("Reference Number")]
        [Required]
        public string ReferenceNumber { get; set; }
        [DisplayName("Student ID")]
        [Required]
        public string StudentID { get; set; }
        [DisplayName("Issue Date")]
        [Required]
        public DateTime IssueDate { get; set; }
        [DisplayName("Return Date")]
        [Required]
        public DateTime ReturnDate { get; set; }
    }
}

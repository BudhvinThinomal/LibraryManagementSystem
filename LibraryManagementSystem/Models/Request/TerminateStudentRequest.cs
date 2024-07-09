using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.Request
{
    public class TerminateStudentRequest
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public DateTime TerminatedDate { get; set; }
    }
}

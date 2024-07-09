using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryManagementSystem.Models.Request
{
    public class EditStudentRequest
    {
        [Required]
        public int StudentId { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string? Address { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Telephone Number should be 10 digits long")]
        [MaxLength(10, ErrorMessage = "Telephone should be Maximum 10 characters long")]
        public string? Telephone { get; set; }
    }
}

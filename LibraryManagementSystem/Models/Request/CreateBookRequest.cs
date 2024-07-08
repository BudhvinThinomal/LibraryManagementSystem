using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models.Request
{
    public class CreateBookRequest
    {
        [Required]
        [MinLength(13, ErrorMessage = "ISBN should be 13 characters long")]
        [MaxLength(13, ErrorMessage = "ISBN should be 13 characters long")]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publication { get; set; }
        public string? Edition { get; set; }
        [DisplayName("Published Year")]
        public int? PublishedYear { get; set; }
        [Required]
        public string Category { get; set; }
        [DisplayName("Number of Copies")]
        [Required]
        public int? NumberOfCopies { get; set; }
    }
}

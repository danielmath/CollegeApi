using System.ComponentModel.DataAnnotations;

namespace College.Application.DTOs
{
    public class UpdateStudentDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        
        public string CourseCode { get; set; } = string.Empty;
    }
}
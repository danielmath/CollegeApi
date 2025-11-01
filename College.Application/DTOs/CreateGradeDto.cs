using System.ComponentModel.DataAnnotations;

namespace College.Application.DTOs
{
    public class CreateGradeDto
    {
        [Required]
        [Range(0, 100)]
        public decimal Value { get; set; }
        
        public int StudentId { get; set; }
        
        public string CourseCode { get; set; } = string.Empty;
    }
}
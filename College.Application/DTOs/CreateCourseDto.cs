using System.ComponentModel.DataAnnotations;

namespace College.Application.DTOs
{
    public class CreateCourseDto
    {
        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;
    }
}
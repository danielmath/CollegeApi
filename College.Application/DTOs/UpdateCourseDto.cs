using System.ComponentModel.DataAnnotations;

namespace College.Application.DTOs
{
    public class UpdateCourseDto
    {
        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;
    }
}
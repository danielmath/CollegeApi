using System.ComponentModel.DataAnnotations;

namespace College.Application.DTOs
{
    public class UpdateGradeDto
    {
        [Required]
        [Range(0, 100)]
        public decimal Value { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace College.Application.DTOs
{
    public class UpdateProfessorDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Area { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace College.Application.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string Usuario { get; set; } = string.Empty;
        
        [Required]
        public string Contraseña { get; set; } = string.Empty;
    }
}
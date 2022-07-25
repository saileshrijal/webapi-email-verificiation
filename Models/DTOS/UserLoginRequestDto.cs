using System.ComponentModel.DataAnnotations;

namespace FormulaOneApp.Models.DTOS
{
    public class UserLoginRequestDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
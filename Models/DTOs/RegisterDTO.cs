using System.ComponentModel.DataAnnotations;

namespace ApiParchePlanU.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "El email es obligatoria")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string password { get; set; } = null!;

        [Required]
        public string fullName { get; set; } = null!;

        [Required]
        public string Program {  get; set; } = null!;

        [Required]
        public string? AvatarUrl { get; set; } = null!;

    }
}

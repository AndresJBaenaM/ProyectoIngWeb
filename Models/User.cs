using Microsoft.AspNetCore.Identity; 
namespace ApiParchePlanU.Models
{
    public class User : IdentityUser
    {
        public string NombreCompleto { get; set; }
        public string Programa  { get; set; }
        public string? AvatarUrl { get; set; }

    }
}

using Microsoft.AspNetCore.Identity; 
namespace ApiParchePlanU.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Email {  get; set; }
        public string Programa  { get; set; }
        public string Password { get; set; }
        public string? AvatarUrl { get; set; }

    }
}

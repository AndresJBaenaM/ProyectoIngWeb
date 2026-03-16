using Microsoft.AspNetCore.Identity;

namespace ApiParchePlanU.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(string fullName, string email, string programa, string password, string URLAvatar);
        Task<string?> Login(string email, string password);
    }
}

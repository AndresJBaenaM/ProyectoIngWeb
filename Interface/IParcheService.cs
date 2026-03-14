using ApiParchePlanU.Models;

namespace ApiParchePlanU.Interface
{
    public interface IParcheService
    {
        Task<List<Parche>> GettAll(); 
        Task<Parche> GettById(int id);
        Task<Parche> Create(Parche parche);
        Task JoinParche(string inviteCode, string userId);
        Task<List<ParcheMember>> GetMembers(int parcheId); 
    }
}

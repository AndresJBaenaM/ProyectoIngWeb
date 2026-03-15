using ApiParchePlanU.Models;

namespace ApiParchePlanU.Interfaces
{
    public interface IRankingServices
    {
        Task<List<Ranking>> GetRanking(int parcheId); 
    }
}

using ApiParchePlanU.Models;

namespace ApiParchePlanU.Interfaces
{
    public interface IRankingService
    {
        Task<List<Ranking>> GetRanking(int parcheId); 
    }
}

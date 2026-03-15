using ApiParchePlanU.DAO;
using ApiParchePlanU.Interface;

namespace ApiParchePlanU.Services
{
    public class RankingService : IRankingService
    {
        private readonly ApplicationDbContext _context;
        public RankingService()
        {
            _context = context; 
        }
        public async Task<object> GetRanking(int parcheId)
        {
            var ranking = await _context.Plans
                .Where(parcheId => parcheId.ParcheId == parcheId)
                .GroupBy(p => p.ParcheId)
                .Select(g => new
                {
                    TotalPlans = g.coutn()
                }).FirstOrDefault();
            return ranking; 
        }
    }
}

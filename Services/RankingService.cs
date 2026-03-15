using ApiParchePlanU.DAO;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiParchePlanU.Services
{
    public class RankingService : IRankingServices
    {
        private readonly ApplicationDbContext _context;
        public RankingService(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<List<Ranking>> GetRanking(int parcheId)
        {
            return await _context.Rankings.Where(r => r.ParcheId == parcheId).ToListAsync();  
        }
    }
}

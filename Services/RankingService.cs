using ApiParchePlanU.DAO;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;
using ApiParchePlanU.Models.Enums;
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
            var members = await _context.ParcheMembers.Where(m => m.Parche_Id == parcheId).ToListAsync(); 
            var rankingList = new List<Ranking>();

            foreach(var member in members)
            {
                var organizerScore = await _context.Plans.Where(p => p.CratorId == member.Id_Usuario && p.Parche_Id == parcheId).CountAsync();

                var ghostScore = await _context.Attendances.Where(a => a.User_Id == member.Id_Usuario && a.Status == AttendanceStatus.Yes).CountAsync();


                rankingList.Add(new Ranking
                {
                    UserId = member.Id_Usuario,
                    ParcheId = parcheId,
                    OrganizerScore = organizerScore,
                    GhosScore = ghostScore

                }); 
            }
            return rankingList;
        }
    }
}

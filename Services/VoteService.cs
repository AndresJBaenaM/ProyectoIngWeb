using ApiParchePlanU.DAO;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;

namespace ApiParchePlanU.Services
{
    public class VoteService : IVoteService
    {
        private readonly ApplicationDbContext _context;
        public VoteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Vote(string userId, int optionId)
        {
            var vote = new Vote
            {
                userId = userId,
                PlanOption = optionId
            };
            await _context.SaveChangeAsync();
        }
        public async Task ChangeVote(string userId, int optionId)
        {
            var vote = await _context.Votes
                .FirtOrDefautl(vote => vote.UserId == userId);
            vote.PlanOption = optionId;
            await _context.SaveChangesAsync();
        }
    }
}

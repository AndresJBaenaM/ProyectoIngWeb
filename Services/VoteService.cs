using ApiParchePlanU.DAO;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;
using Microsoft.EntityFrameworkCore;

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
            var option = await _context.PlanOptions
                .FirstOrDefaultAsync(o => o.Id == optionId);

            if (option == null)
                throw new Exception("Option not found");

            var plan = await _context.Plans
                .FirstOrDefaultAsync(p => p.Id == option.Plan_Id);

            var now = DateTime.UtcNow;

            if (now < plan.StartVoting || now > plan.EndVoting)
                throw new Exception("Voting closed");

            var existingVote = await _context.Votes
                .FirstOrDefaultAsync(v => v.Usuario_Id == userId && v.Plan_Id == plan.Id);

            if (existingVote != null)
                throw new Exception("User already voted");

            var vote = new Vote
            {
                Usuario_Id = userId,
                PlanOptionId = optionId,
                Plan_Id = plan.Id
            };

            _context.Votes.Add(vote);

            await _context.SaveChangesAsync();
        }

        public async Task ChangeVote(string userId, int optionId)
        {
            var option = await _context.PlanOptions
                .FirstOrDefaultAsync(o => o.Id == optionId);

            var vote = await _context.Votes
                .FirstOrDefaultAsync(v => v.Usuario_Id == userId && v.Plan_Id == option.Plan_Id);

            if (vote == null)
                throw new Exception("Vote not found");

            vote.PlanOptionId = optionId;

            await _context.SaveChangesAsync();
        }

        public async Task<object> GetResults(int planId)
        {
            var options = await _context.PlanOptions
                .Where(o => o.Plan_Id == planId)
                .ToListAsync();

            var totalVotes = await _context.Votes
                .CountAsync(v => v.Plan_Id == planId);

            var results = options.Select(o => new
            {
                option = o.Lugar,
                votes = _context.Votes.Count(v => v.PlanOptionId == o.Id),
                percentage = totalVotes == 0 ? 0 :
                    (_context.Votes.Count(v => v.PlanOptionId == o.Id) * 100.0) / totalVotes
            });

            return results;
        }
    }
}

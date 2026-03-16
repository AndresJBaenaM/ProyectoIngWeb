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
            var vote = new Vote
            {
                Usuario_Id = userId,
                PlanOptionId = optionId
            };
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
        }
        public async Task ChangeVote(string userId, int optionId)
        {
            var vote = await _context.Votes.FirstOrDefaultAsync(vote => vote.Usuario_Id == userId);
            if (vote == null)
                return; 
            
            vote.PlanOptionId = optionId;
            await _context.SaveChangesAsync();
        }
    }
}

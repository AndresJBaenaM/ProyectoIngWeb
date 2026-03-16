using ApiParchePlanU.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiParchePlanU.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost]
        public async Task<IActionResult> Vote(string userId, int optionId)
        {
            await _voteService.Vote(userId, optionId);
            return Ok("Vote registered");
        }

        [HttpPut]
        public async Task<IActionResult> ChangeVote(string userId, int optionId)
        {
            await _voteService.ChangeVote(userId, optionId);
            return Ok("Vote updated");
        }

        [HttpGet("results/{planId}")]
        public async Task<IActionResult> GetResults(int planId)
        {
            var results = await _voteService.GetResults(planId);
            return Ok(results);
        }
    }
}
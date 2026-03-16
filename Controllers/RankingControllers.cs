using Microsoft.AspNetCore.Mvc;
using ApiParchePlanU.Interfaces;
using ApiParchePlanU.Models;

namespace ApiParchePlanU.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankingController : ControllerBase
    {
        private readonly IRankingService _rankingService;

        public RankingController(IRankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet("{parcheId}")]
        public async Task<ActionResult<List<Ranking>>> GetRanking(int parcheId)
        {
            var ranking = await _rankingService.GetRanking(parcheId);
            return Ok(ranking);
        }
    }
}

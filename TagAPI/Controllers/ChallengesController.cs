using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TagAPI.Data;
using TagAPI.Models;
using TagAPI.ModelsDTO;

namespace TagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        private readonly DataContext _context;
        public ChallengesController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("AddChallenge/")]
        public async Task<ActionResult<ChallengeCard>> CreateChallenge([FromBody] ChallengeCardDTO request)
        {
            var challengeCard = new ChallengeCard 
            { 
                Title = request.Title,
                Description = request.Description,
                Reward = request.Reward,
            };
            _context.ChallengeCards.Add(challengeCard);
            await _context.SaveChangesAsync();
            return Ok(challengeCard);
        }
        [HttpGet("AllChallenges/")]
        public async Task<ActionResult<List<ChallengeCardDTO>>> GetAllChallenges()
        {
            var challenges = await _context.ChallengeCards.ToListAsync();

            return Ok(challenges);
        }
    }
}

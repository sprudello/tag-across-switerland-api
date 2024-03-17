using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TagAPI.Data;
using TagAPI.Models;
using TagAPI.ModelsDTO;

namespace TagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("GetRandom/")]
        public async Task<ActionResult<ChallengeCardDTO>> GetRandomChallenge()
        {
            Random random = new Random();
            int count = _context.ChallengeCards.Count();
            if (count == 0)
            {
                return NotFound("No challenges available.");
            }
            int index = random.Next(0, count);
            ChallengeCard challenge = await _context.ChallengeCards.Skip(index).FirstOrDefaultAsync();
            if (challenge == null)
            {
                return NotFound("Challenge not found.");
            }
            var challengeDTO = new ChallengeCardDTO
            {
                Description = challenge.Description,
                Reward = challenge.Reward,
                Title = challenge.Title,
            };
            return Ok(challengeDTO);
        }
        [HttpPost("AssignChallenge/")]
        public async Task<IActionResult> AssignChallenge()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            int userId = 0;
            foreach(User user in _context.Users)
            {
                if (user.Username == username)
                {
                    userId = user.Id;
                    break;
                }
            }
            Random random = new Random();
            int count = _context.ChallengeCards.Count();
            if (count == 0)
            {
                return NotFound("No challenges available.");
            }
            int index = random.Next(0, count);
            ChallengeCard challenge = await _context.ChallengeCards.Skip(index).FirstOrDefaultAsync();
            if (challenge == null)
            {
                return NotFound("Challenge not found.");
            }
            var challengeDTO = new ChallengeCardDTO
            {
                Description = challenge.Description,
                Reward = challenge.Reward,
                Title = challenge.Title,
            };
            var userChallenge = new UserChallenge()
            {
                UserID = userId,
                CardID = challenge.Id,
                StartTime = DateTime.UtcNow,
                Status = "started"
            };
            _context.UserChallenges.Add(userChallenge);
            _context.SaveChanges();

            return Ok(challengeDTO);
        }
        [HttpPut("ChallengeSuccess/")]
        public async Task<IActionResult> UpdateChallengeSuccess()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            int userId = 0;
            foreach (User item in _context.Users)
            {
                if (item.Username == username)
                {
                    userId = item.Id;
                    break;
                }
            }
            
        }
    }
}

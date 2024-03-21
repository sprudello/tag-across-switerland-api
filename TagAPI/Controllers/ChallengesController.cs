using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            int userId = _context.Users.FirstOrDefault(c => c.Username == username).Id;
            if (userId == 0 || userId == null)
            {
                return BadRequest("User not found.");
            }
            User user = _context.Users.FirstOrDefault(c => c.Id == userId);
            if (user.PenaltyEndTime > DateTime.UtcNow)
            {
                return Ok("You still have a penalty.");
            }
            Random random = new Random();
            int count = _context.ChallengeCards.Count();
            if (count == 0)
            {
                return NotFound("No challenges available.");
            }
            List<int> everyUserChallengeId = _context.UserChallenges
                .Where(c => c.UserID == userId)
                .Select(uc => uc.CardID)
                .ToList();
            var startedChallenges = _context.UserChallenges.FirstOrDefault(c => c.UserID == userId && c.Status == "started");
            if (startedChallenges != null)
            {
                return BadRequest("You have already started a challenge.");
            }
            if (everyUserChallengeId.Count == count)
            {
                return Ok("You already have done all available challenges");
            }
            bool isValid = true;
            int index;
            do
            {
                index = random.Next(0, count);
                if (!everyUserChallengeId.Contains(index))
                {
                    isValid = false;
                }
            } while (isValid);
            ChallengeCard challenge = _context.ChallengeCards.Skip(index).FirstOrDefault();
            
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
            var userChallenge = _context.UserChallenges
                .FirstOrDefault(c => c.UserID == userId && c.Status == "started");
            if (userChallenge == null)
            {
                return BadRequest("You haven't started a challenge... Yet");
            }
            var user = _context.Users
                .FirstOrDefault(c => c.Id == userId);
            var challenge = _context.ChallengeCards.FirstOrDefault(c => c.Id == userChallenge.CardID);
            userChallenge.Status = "success";
            userChallenge.EndTime = DateTime.UtcNow;
            if(user.HasMultiplier)
            {
                user.GottstattCoins += (challenge.Reward * 2);
                user.HasMultiplier = false;
            }
            else
            {
                user.GottstattCoins += challenge.Reward;
            }
            
            _context.SaveChanges();
            return Ok("Callenge Successfully");
        }
        [HttpGet("CurrentChallenge/")]
        public async Task<IActionResult> GetCurrentChallenge()
        {
            string username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("User is not authenticated.");
            }

            // Use asynchronous database access
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Username == username);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Retrieve the current challenge for the user asynchronously and safely
            var userChallenge = await _context.UserChallenges.FirstOrDefaultAsync(uc => uc.UserID == user.Id && uc.Status == "started");

            if (userChallenge == null)
            {
                return NotFound("No active challenge found for the user.");
            }

            var challengeCard = await _context.ChallengeCards.FirstOrDefaultAsync(c => c.Id == userChallenge.CardID);

            if (challengeCard == null)
            {
                return NotFound("Challenge not found.");
            }

            return Ok(challengeCard);
        }
        [HttpPatch("VetoChallenge/")]
        public async Task<IActionResult> VetoChallenge()
        {
            string username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("User is not authenticated.");
            }

            // Use asynchronous database access
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Username == username);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Retrieve the current challenge for the user asynchronously and safely
            var userChallenge = await _context.UserChallenges.FirstOrDefaultAsync(uc => uc.UserID == user.Id && uc.Status == "started");

            if (userChallenge == null)
            {
                return NotFound("No active challenge found for the user.");
            }
            userChallenge.Status = "failed";
            userChallenge.EndTime = DateTime.UtcNow;
            user.PenaltyEndTime = DateTime.UtcNow.AddMinutes(30);
            _context.SaveChanges();
            return Ok("Challenge failed successfully");
        }
    }
}

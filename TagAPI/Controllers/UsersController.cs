using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TagAPI.Data;
using TagAPI.Models;
using TagAPI.ModelsDTO;

namespace TagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost("register/")]
        public IActionResult Register([FromBody] UserDTO request)
        {
            if (_context.Users.Any(u => u.Username == request.UserName))
            {
                return BadRequest(new { message = "Username already exists." });
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                Username = request.UserName,
                PasswordHash = hashedPassword,
                HasMultiplier = false,
                GottstattCoins = 2000,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(new { message = "User registered successfully." });
        }
        [HttpPost("login/")]
        public IActionResult Login([FromBody] UserDTO request)
        {
            // Find the user by email
            var user = _context.Users.FirstOrDefault(u => u.Username == request.UserName);

            // Check if user exists and the password is correct
            if (user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                // Authentication successful
                // For simplicity, we're just returning a success response.
                // In a real application, you would issue a token or set a cookie here.
                string token = CreateToken(user);
                return Ok(new { message = "User logged in successfully.", token = token });
            }

            // Authentication failed
            return Unauthorized(new { message = "Wrong Pass or Username" });
        }
        [HttpGet("Balance/")]
        public async Task<IActionResult> GetBalance()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var user = _context.Users.FirstOrDefault(c => c.Username == username);
            if (username == null)
            {
                return BadRequest(new { message = "User not logged in." });
            }

            return Ok(new { balance = $"{user.GottstattCoins} GC" });
        }
        [HttpGet("Profile/")]
        public async Task<IActionResult> GetProfile()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var user = _context.Users.FirstOrDefault(c => c.Username == username);
            if (username == null)
            {
                return BadRequest(new { message = "User not logged in." });
            }
            UserInfoDTO userInfo = new UserInfoDTO
            {
                Username = user.Username,
                HasMultiplier = user.HasMultiplier,
                PenaltyEndTime = user.PenaltyEndTime.AddHours(2).ToString($"dd.MM | HH:mm"),
                GottstattCoins = user.GottstattCoins
            };
            return Ok(userInfo);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(365),
                    signingCredentials: credentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

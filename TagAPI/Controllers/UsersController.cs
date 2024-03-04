using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register/")]
        public IActionResult Register([FromBody] UserDTO rquest)
        {
            if (_context.Users.Any(u => u.UserName == rquest.UserName))
            {
                return BadRequest("Username already exists.");
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(rquest.Password);

            var newUser = new User
            {
                UserName = rquest.UserName,
                PasswordHash = hashedPassword,
                GottstattCoins = 1000,
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO request)
        {
            // Find the user by email
            var user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);

            // Check if user exists and the password is correct
            if (user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                // Authentication successful
                // For simplicity, we're just returning a success response.
                // In a real application, you would issue a token or set a cookie here.
                return Ok("User logged in successfully.");
            }

            // Authentication failed
            return Unauthorized("Invalid credentials.");
        }
    }
}

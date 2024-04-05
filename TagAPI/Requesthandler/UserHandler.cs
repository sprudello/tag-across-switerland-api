using System.Security.Claims;
using TagAPI.Data;
using TagAPI.Models;

namespace TagAPI.Requesthandler
{
    public class UserHandler
    {
        private readonly DataContext _context;
        public UserHandler(DataContext context)
        {
            _context = context;
        }

        public User GetUser(Claim claim)
        {
            var username = claim.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            return string.IsNullOrEmpty(username) ? null : _context.Users.FirstOrDefault(c => c.Username == username);
        }
    }
}

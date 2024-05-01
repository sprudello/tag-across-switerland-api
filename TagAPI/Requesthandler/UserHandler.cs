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
    }
}

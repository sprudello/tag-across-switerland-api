using System.Reflection.Metadata.Ecma335;

namespace TagAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; } = string.Empty;
        public required string PasswordHash { get; set; } = string.Empty;
        public required int GottstattCoins { get; set; }
    }
}
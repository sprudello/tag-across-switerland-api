using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata.Ecma335;

namespace TagAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; } = string.Empty;
        public required string PasswordHash { get; set; } = string.Empty;
        public required int GottstattCoins { get; set; }
        public required bool HasMultiplier { get; set; }
        public DateTime PenaltyEndTime { get; set; }
    }
}
using System.Reflection.Metadata.Ecma335;

namespace TagAPI.Models
{
    public class ChallengeCard
    {
        public int CardID { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required int Reward { get; set; }

    }
}

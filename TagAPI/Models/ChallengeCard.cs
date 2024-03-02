using System.Reflection.Metadata.Ecma335;

namespace TagAPI.Models
{
    /// <summary>
    /// You need "Title", "Description", "Reward"
    /// </summary>
    public class ChallengeCard
    {
        public int Id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required int Reward { get; set; }

    }
}

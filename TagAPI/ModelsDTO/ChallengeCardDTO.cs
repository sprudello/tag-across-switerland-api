namespace TagAPI.ModelsDTO
{
    public class ChallengeCardDTO
    {
        public required string Title { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required int Reward { get; set; }
    }
}

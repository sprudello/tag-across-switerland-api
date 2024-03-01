namespace TagAPI.Models
{
    public class Group
    {
        public int ID { get; set; }
        public required string GroupName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int GottstattCoins { get; set; }
    }
    class ChallengeCard
    {
        public int CardID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Reward { get; set; }

    }
}

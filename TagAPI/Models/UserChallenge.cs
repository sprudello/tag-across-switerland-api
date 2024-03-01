namespace TagAPI.Models
{
    public class UserChallenge
    {
        public int UserChallengeID { get; set; }
        public required int UserID { get; set; }
        public required int CardID { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

namespace TagAPI.Models
{
    public class GroupChallenge
    {
        public int GroupChallengeID { get; set; }
        public int GroupID { get; set; }
        public int CardID { get; set; }
        public required DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

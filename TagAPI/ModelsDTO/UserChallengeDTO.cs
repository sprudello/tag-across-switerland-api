namespace TagAPI.ModelsDTO
{
    public class UserChallengeDTO
    {
        public required int UserID { get; set; }
        public required int CardID { get; set; }
        public required DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime PenaltyEndTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

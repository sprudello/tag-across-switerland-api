namespace TagAPI.ModelsDTO
{
    public class UserInfoDTO
    {
        public required string Username { get; set; } = string.Empty;
        public required bool HasMultiplier { get; set; }
        public required int GottstattCoins { get; set; }
        public string PenaltyEndTime { get; set; }
    }
}

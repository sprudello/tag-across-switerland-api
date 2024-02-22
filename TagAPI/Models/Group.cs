namespace TagAPI.Models
{
    public class Group
    {
        public int ID { get; set; }
        public required string GroupName { get; set; } = string.Empty;
        public string PasswordHash { get; set; }
        public int GottstattCoins { get; set; }
    }
    public class GroupChallenge
    {

    }
}

namespace TagAPI.Models
{
    public class UserTransaction
    {
        public int TransactionID { get; set; }
        public int GroupID { get; set; }
        public int Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
    }
}

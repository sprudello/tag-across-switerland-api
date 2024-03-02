using System.Text.RegularExpressions;

namespace TagAPI.Models
{
    public class UserTransaction
    {
        public int Id { get; set; }
        public required int UserID { get; set; }
        public required int Amount { get; set; }
        public required string TransactionType { get; set; } = string.Empty;
        public required DateTime TransactionDate { get; set; }
        public User User { get; set; }
    }
}

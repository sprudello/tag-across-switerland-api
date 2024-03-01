namespace TagAPI.Models
{
    public class UserItem
    {
        public int UserItemID { get; set; }
        public required int UserID { get; set; }
        public required int ItemID { get; set; }
        public required DateTime PurchaseDate { get; set; }
    }
}

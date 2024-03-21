namespace TagAPI.ModelsDTO
{
    public class UserItemDTO
    {
        public required int UserID { get; set; }
        public required int ItemID { get; set; }
        public required DateTime PurchaseDate { get; set; }
    }
}

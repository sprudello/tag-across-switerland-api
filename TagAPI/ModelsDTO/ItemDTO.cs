namespace TagAPI.ModelsDTO
{
    public class ItemDTO
    {
        public required string ItemName { get; set; } = string.Empty;
        public required string Description { get; set; }
        public required int ItemPrice { get; set; }
    }
}

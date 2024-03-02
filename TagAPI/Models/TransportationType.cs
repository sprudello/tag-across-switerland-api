namespace TagAPI.Models
{
    public class TransportationType
    {
        public int TypeID { get; set; }
        public required string TypeName { get; set; } = string.Empty;
        public required int FeePerMinute { get; set; }
    }
}

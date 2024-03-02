namespace TagAPI.Models
{
    public class TransportationType
    {
        public int Id { get; set; }
        public required string TypeName { get; set; } = string.Empty;
        public required int FeePerMinute { get; set; }
    }
}

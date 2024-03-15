namespace TagAPI.ModelsDTO
{
    public class TransportationDTO
    {
        public required string TypeName { get; set; } = string.Empty;
        public required int FeePerMinute { get; set; }
    }
}

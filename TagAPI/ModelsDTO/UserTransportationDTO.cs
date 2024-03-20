namespace TagAPI.ModelsDTO
{
    public class UserTransportationDTO
    {
        public required int UserID { get; set; }
        public required int TypeID { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required int Duration { get; set; }
        public required int TotalCost { get; set; }
    }
}

namespace TagAPI.Models
{
    public class UserTransportation
    {
        public int UserTransportID { get; set; }
        public int UserID { get; set; }
        public int ModelID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public int TotalCost { get; set; }
    }
}

using System.Text.RegularExpressions;

namespace TagAPI.Models
{
    public class UserTransportation
    {
        public int UserTransportID { get; set; }
        public required int UserID { get; set; }
        public required int TypeID { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime EndTime { get; set; }
        public required int Duration { get; set; }
        public required int TotalCost { get; set; }

        public User User { get; set; }
        public TransportationType TransportationType { get; set; }
    }
}

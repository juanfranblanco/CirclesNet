using Circles.RPC.Requests.DTOs;

namespace Circles.RPC.Requests.DTO
{
    public class TrustListRow: EventRow
    {
        public long Timestamp { get; set; }
        public string Trustee { get; set; }
        public string Truster { get; set; }

        public long ExpiryTime { get; set; }

        public long Limit { get; set; }
    }
}


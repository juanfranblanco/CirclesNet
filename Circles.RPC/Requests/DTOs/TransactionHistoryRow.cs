using Circles.RPC.Requests.DTOs;

namespace Circles.RPC.Requests.DTO
{


    public class TransactionHistoryRow : EventRow
    {
        public long Timestamp { get; set; }
        public int Version { get; set; }
        public string Operator { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string TokenType { get; set; }
    }
}


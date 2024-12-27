namespace Circles.RPC.Requests.DTOs
{
    public class EventRow
    {
        public long BlockNumber { get; set; }
        public int TransactionIndex { get; set; }
        public int LogIndex { get; set; }
        public int BatchIndex { get; set; }
        public string TransactionHash { get; set; }
    }

}

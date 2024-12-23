namespace Circles.RPC.Requests.DTO
{
    /// <summary>
    /// Represents the avatar information returned from the Circles RPC.
    /// </summary>
    public class AvatarRow
    {
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TokenId { get; set; }
        public long BlockNumber { get; set; }
        public string TransactionHash { get; set; }
        public DateTime Timestamp { get; set; }
    }
}


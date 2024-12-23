namespace Circles.RPC.Requests.DTO
{
    /// <summary>
    /// Represents a generic paginated response.
    /// </summary>
    public class Page<T>
    {
        /// <summary>
        /// The rows of the current page.
        /// </summary>
        public List<T> Rows { get; set; } = new();

        /// <summary>
        /// The size of the page (number of rows requested).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The total number of rows available, if provided.
        /// </summary>
        public int TotalRows { get; set; }
    }

    public class TransactionHistoryRow
    {
        public long BlockNumber { get; set; }
        public long Timestamp { get; set; }
        public int TransactionIndex { get; set; }
        public int LogIndex { get; set; }
        public int BatchIndex { get; set; }
        public string TransactionHash { get; set; }
        public int Version { get; set; }
        public string? Operator { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string TokenType { get; set; }
    }
}


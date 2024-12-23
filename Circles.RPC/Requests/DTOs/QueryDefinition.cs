using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X509;

namespace Circles.RPC.Requests.DTOs
{
    /// <summary>
    /// Represents the query definition for a `circles_query` request.
    /// </summary>
    public class QueryDefinition
    {
        [JsonProperty("Namespace")]
        public string Namespace { get; set; } = string.Empty;

        [JsonProperty("Table")]
        public string Table { get; set; } = string.Empty;

        [JsonProperty("Columns")]
        public List<string> Columns { get; set; } = new();

        [JsonProperty("Filter")]
        public List<Filter> Filter { get; set; } = new();

        [JsonProperty("Order")]
        public List<Order> Order { get; set; } = new();

        [JsonProperty("Limit")]
        public int Limit { get; set; } = 100;
    }

}

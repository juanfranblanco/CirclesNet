using Newtonsoft.Json;

namespace Circles.RPC.Requests.DTOs
{
    public class CirclesQueryResponse
    {
        [JsonProperty("columns")]
        public List<string> Columns { get; set; } = new();

        [JsonProperty("rows")]
        public List<List<object>> Rows { get; set; } = new();
    }
}

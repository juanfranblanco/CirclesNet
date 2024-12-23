using Newtonsoft.Json;

namespace Circles.RPC.Requests.DTOs
{
    public class CirclesQueryPage
    {
        [JsonProperty("columns")]
        public List<string> Columns { get; set; } = new();

        [JsonProperty("rows")]
        public List<string[]> Rows { get; set; } = new();

        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("totalRows")]
        public int TotalRows { get; set; }  // Optional, if provided by the API
    }
}


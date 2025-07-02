using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PathOfRegex.Models.Item
{
    public class ItemResponse
    {
        [JsonProperty("lines")]
        public List<ItemLine> Lines { get; set; }
    }
}

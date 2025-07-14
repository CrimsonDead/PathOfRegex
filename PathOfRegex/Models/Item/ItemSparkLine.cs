using Newtonsoft.Json;

namespace PathOfRegex.Models.Item
{
    public class ItemSparkLine
    {
        [JsonProperty("data")]
        public List<double?> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }
}

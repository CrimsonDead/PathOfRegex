using Newtonsoft.Json;

namespace PathOfRegex.Models.Item
{
    public class ItemModifier
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("optional")]
        public bool Optional { get; set; }
    }
}

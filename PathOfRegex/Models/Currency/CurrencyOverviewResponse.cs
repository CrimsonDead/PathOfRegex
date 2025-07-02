using Newtonsoft.Json;

namespace PathOfRegex.Models.Currency
{
    public class CurrencyOverviewResponse
    {
        [JsonProperty("lines")]
        public List<CurrencyLine> Lines { get; set; }
    }
}

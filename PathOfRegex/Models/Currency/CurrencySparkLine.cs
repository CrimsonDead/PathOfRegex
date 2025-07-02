using Newtonsoft.Json;

namespace PathOfRegex.Models.Currency
{
    public class CurrencySparkLine
    {
        [JsonProperty("data")]
        public List<double> Data { get; set; }

        [JsonProperty("totalChange")]
        public double TotalChange { get; set; }
    }
}

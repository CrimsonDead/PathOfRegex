using Newtonsoft.Json;

namespace PathOfRegex.Models.Currency
{
    public class CurrencyLine
    {
        [JsonProperty("currencyTypeName")]
        public string CurrencyTypeName { get; set; }

        [JsonProperty("pay")]
        public CurrencyTradeInfo Pay { get; set; }

        [JsonProperty("receive")]
        public CurrencyTradeInfo Receive { get; set; }

        [JsonProperty("paySparkLine")]
        public CurrencySparkLine PaySparkLine { get; set; }

        [JsonProperty("receiveSparkLine")]
        public CurrencySparkLine ReceiveSparkLine { get; set; }

        [JsonProperty("lowConfidencePaySparkLine")]
        public CurrencySparkLine LowConfidencePaySparkLine { get; set; }

        [JsonProperty("lowConfidenceReceiveSparkLine")]
        public CurrencySparkLine LowConfidenceReceiveSparkLine { get; set; }

        [JsonProperty("chaosEquivalent")]
        public double ChaosEquivalent { get; set; }

        [JsonProperty("detailsId")]
        public string DetailsId { get; set; }
    }
}

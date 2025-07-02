using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PathOfRegex.Models.Item
{
    public class ItemLine
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("mapTier")]
        public int MapTier { get; set; }

        [JsonProperty("baseType")]
        public string BaseType { get; set; }

        [JsonProperty("stackSize")]
        public int StackSize { get; set; }

        [JsonProperty("itemClass")]
        public int ItemClass { get; set; }

        [JsonProperty("sparkline")]
        public ItemSparkLine Sparkline { get; set; }

        [JsonProperty("lowConfidenceSparkline")]
        public ItemSparkLine LowConfidenceSparkline { get; set; }

        [JsonProperty("implicitModifiers")]
        public List<ItemModifier> ImplicitModifiers { get; set; }

        [JsonProperty("explicitModifiers")]
        public List<ItemModifier> ExplicitModifiers { get; set; }

        [JsonProperty("flavourText")]
        public string FlavourText { get; set; }

        [JsonProperty("chaosValue")]
        public double ChaosValue { get; set; }

        [JsonProperty("exaltedValue")]
        public double ExaltedValue { get; set; }

        [JsonProperty("divineValue")]
        public double DivineValue { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("detailsId")]
        public string DetailsId { get; set; }

        [JsonProperty("tradeInfo")]
        public List<object> TradeInfo { get; set; }

        [JsonProperty("listingCount")]
        public int ListingCount { get; set; }
    }
}

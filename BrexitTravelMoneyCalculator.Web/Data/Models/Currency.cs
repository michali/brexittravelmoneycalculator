using Newtonsoft.Json;
namespace BrexitTravelMoneyCalculator.Web.Data.Models
{
    public class Currency
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "exchange_rate")]
        public double ExchangeRate { get; set; }

        [JsonPropertyAttribute(PropertyName = "pre_ref_exchange_rate")]
        public double PreRefExchangeRate { get; internal set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
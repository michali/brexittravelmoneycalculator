using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Data.Models
{
    public class Currency : Document
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "exchange_rate")]
        public double ExchangeRate { get; set; }
    }
}
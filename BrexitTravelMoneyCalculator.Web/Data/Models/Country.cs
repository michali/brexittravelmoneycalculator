using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Web.Data.Models
{
    public class Country
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "local_product")]
        public LocalProduct LocalProduct {get;set;}
    }
}
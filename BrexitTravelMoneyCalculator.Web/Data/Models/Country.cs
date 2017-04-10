using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Web.Data.Models
{
    public class Country
    {
        [JsonProperty(PropertyName = "id")]
        public string Id {get;set;}
        public string Name {get;set;}
        [JsonProperty(PropertyName="currency_id")]
        public string CurrencyId{get;set;}
        public string Type{get;set;}
    }
}
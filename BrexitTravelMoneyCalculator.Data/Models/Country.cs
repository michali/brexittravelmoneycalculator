using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Data.Models
{
    public class Country : Document
    {
        public string Name {get;set;}
        [JsonProperty(PropertyName="currency_id")]
        public string CurrencyId{get;set;}
    }
}
using Newtonsoft.Json;

namespace brexittravelmoneycalculator.data.Models
{
    public class Country : IDocument
    {
        [JsonProperty(PropertyName = "id")]
        public string Id {get;set;}
        public string Name {get;set;}
        [JsonProperty(PropertyName="currency_id")]
        public string CurrencyId{get;set;}
    }
}
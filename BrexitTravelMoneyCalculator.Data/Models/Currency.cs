using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Data.Models
{
    public class Currency : IDocument
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Code {get;set;}
        public string Name { get; set; }
        public double ExchangeRate { get; set; }
    }
}
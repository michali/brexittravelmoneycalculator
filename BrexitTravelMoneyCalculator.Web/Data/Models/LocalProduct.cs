using Newtonsoft.Json;
namespace BrexitTravelMoneyCalculator.Web.Data.Models
{
    public class LocalProduct
    {
        [JsonProperty(PropertyName = "nameSingular")]
        public string NameSingular { get; set; }

        [JsonProperty(PropertyName = "namePlural")]
        public string NamePlural { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price {get;set;}
    }
}
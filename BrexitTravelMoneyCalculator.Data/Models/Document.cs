using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Data.Models
{
    public abstract class Document
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string Type {
            get{
                return this.GetType().Name;
            }
        }
    }
}
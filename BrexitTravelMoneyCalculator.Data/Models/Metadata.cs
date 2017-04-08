using System;
using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Data.Models
{
    public class Metadata : IDocument
    {
        [JsonProperty(PropertyName = "id")]
        public string Id{get;set;}
        [JsonProperty(PropertyName = "last_updated")]
        public DateTime LastUpdated {get;set;}
    }
}
using System;
using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Data.Models
{
    public class Metadata : Document
    {
        [JsonProperty(PropertyName = "last_updated")]
        public DateTime LastUpdated {get;set;}
    }
}
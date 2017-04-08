using System;
using Newtonsoft.Json;

namespace brexittravelmoneycalculator.data.Models
{
    public class Metadata : IDocument
    {
        [JsonProperty(PropertyName = "id")]
        public string Id{get;set;}
        [JsonProperty(PropertyName = "last_updated")]
        DateTime LastUpdated{get;set;}
    }
}
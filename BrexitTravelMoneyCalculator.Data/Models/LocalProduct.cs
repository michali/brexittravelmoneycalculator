using Newtonsoft.Json;

public class LocalProduct
{
    [JsonProperty(PropertyName = "name_singular")]
    public string NameSingular { get; set; }

    [JsonProperty(PropertyName = "name_plural")]
    public string NamePlural { get; set; }

    [JsonProperty(PropertyName = "price")]
    public double Price { get; set; }
}
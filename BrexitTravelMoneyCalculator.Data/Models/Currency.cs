using Newtonsoft.Json;

namespace BrexitTravelMoneyCalculator.Data.Models
{
    public class Currency : Document
    {
        public string Code {get;set;}
        public string Name { get; set; }
        public double ExchangeRate { get; set; }
    }
}
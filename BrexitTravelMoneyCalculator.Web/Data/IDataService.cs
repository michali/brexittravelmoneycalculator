using BrexitTravelMoneyCalculator.Web.Data.Models;
using System.Collections.Generic;

namespace BrexitTravelMoneyCalculator.Web.Data
{
    public interface IDataService
    {
        IEnumerable<Country> GetCountries();
        object GetVerdict(string countryId);
    }
}
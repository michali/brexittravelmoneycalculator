using System.Collections.Generic;
using BrexitTravelMoneyCalculator.Web.Data.Models;

namespace BrexitTravelMoneyCalculator.Web.Data
{
    public interface IDbService
    {
        IEnumerable<Country> GetCountries();
        Country GetCountry(string countryId);
        Currency GetCurrency(string currencyId);
    }
}
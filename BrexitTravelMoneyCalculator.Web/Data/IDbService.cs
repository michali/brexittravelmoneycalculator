using System.Collections.Generic;
using System.Linq;
using BrexitTravelMoneyCalculator.Web.Data.Models;

namespace BrexitTravelMoneyCalculator.Web.Data
{
    public interface IDbService
    {
        IEnumerable<Country> GetCountries();
    }
}
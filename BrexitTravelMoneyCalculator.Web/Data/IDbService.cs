using System.Linq;
using BrexitTravelMoneyCalculator.Web.Data.Models;

namespace BrexitTravelMoneyCalculator.Web.Data
{
    public interface IDbService
    {
        IQueryable<Country> GetCountries();
    }
}
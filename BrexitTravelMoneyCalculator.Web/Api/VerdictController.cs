using BrexitTravelMoneyCalculator.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace BrexitTravelMoneyCalculator.Web.Api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VerdictController : Controller
    {
        private IDbService dbService;

        public VerdictController(IDbService dbService)
        {
            this.dbService = dbService;
        }
        [HttpGet]
        public IActionResult Get(int amount, string countryId)
        {
            var country = dbService.GetCountry(countryId);
            var currency = dbService.GetCurrency(country.CurrencyId);

            return Ok(new {
                Country = new {
                    Name = country.Name,
                    Currency = new {
                        Code = currency.Code,
                        PreRefExchangeRate = currency.PreRefExchangeRate,
                        ExchangeRate = currency.ExchangeRate
                    },
                    LocalProduct = country.LocalProduct
                }
            });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using BrexitTravelMoneyCalculator.Web.Data;
using System.Linq;

namespace BrexitTravelMoneyCalculator.Web.Api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountriesController : Controller
    {
        private IDbService dbService;

        public CountriesController(IDbService dbService)
        {
            this.dbService = dbService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var countries = dbService.GetCountries();
            if (!countries.Any())
            {
                return NotFound();
            }            

            return Ok(countries);
        }
    }    
}

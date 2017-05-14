using Microsoft.AspNetCore.Mvc;
using BrexitTravelMoneyCalculator.Web.Data;
using System.Linq;

namespace BrexitTravelMoneyCalculator.Web.Api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountriesController : Controller
    {
        private IDataService dataService;

        public CountriesController(IDataService dataService)
        {
            this.dataService = dataService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var countries = dataService.GetCountries();
            if (!countries.Any())
            {
                return NoContent();
            }   

            return Ok(countries.Select(c=>new{c.Id, c.Name}));
        }
    }    
}

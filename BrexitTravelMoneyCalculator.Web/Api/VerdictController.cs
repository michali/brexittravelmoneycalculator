using BrexitTravelMoneyCalculator.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace BrexitTravelMoneyCalculator.Web.Api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VerdictController : Controller
    {
        private IDataService dataService;

        public VerdictController(IDataService dataService)
        {
            this.dataService = dataService;
        }
        [HttpGet]
        public IActionResult Get(int amount, string countryId)
        {
            var verdict = dataService.GetVerdict(countryId);

            if (verdict == null)
            {
                return NotFound();
            }            

            return Ok(verdict);
        }
    }
}

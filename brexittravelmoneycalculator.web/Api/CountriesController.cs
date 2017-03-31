using Microsoft.AspNetCore.Mvc;

namespace BrexitTravelMoneyCalculatorWeb.Api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CountriesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] {
                new Country{
                    Code="SE",
                    Name="Sweden"
                },
                new Country{
                    Code="PT",
                    Name="Portugal"
                }
            });
        }
    }

    public class Country{
        public string Name;
        public string Code;
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BrexitTravelMoneyCalculatorWeb.Api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LostMoneyController : Controller
    {
        [HttpGet]
        [Produces(typeof(string[]))]
        public IActionResult Get()
        {
            return Ok(new[] {
                "Gollum",
                "Gandalf",
                "Legolas",
                "Aragorn",
                "Frodo Baggins",
                "Bilbo Baggins",
                "Saruman",
                "Gimli",
                "Galadriel"
            });
        }
    }
}

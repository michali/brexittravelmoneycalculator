using Microsoft.AspNetCore.Mvc;

namespace BrexitTravelMoneyCalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

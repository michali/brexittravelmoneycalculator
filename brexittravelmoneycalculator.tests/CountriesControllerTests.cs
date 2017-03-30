using System;
using BrexitTravelMoneyCalculatorWeb.Controllers;
using Xunit;

namespace Brexittravelmoneycalculator.Tests
{
    public class CountriesControllerTests
    {
        [Fact]
        public void Returns_Verdict()
        {
            var controller = new CountriesController();

            var result = controller.GetAll();


        }
    }
}

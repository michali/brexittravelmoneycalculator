using System;
using BrexitTravelMoneyCalculatorWeb.Api;
using Xunit;
using Microsoft.AspNetCore.Mvc.Core;

namespace Brexittravelmoneycalculator.Tests
{
    public class CountriesControllerTests
    {
        [Fact]
        public void Returns_Verdict()
        {
            var controller = new CountriesController();

            var result = controller.Get();

            Assert.IsType<OkResult>(result);
        }
    }
}

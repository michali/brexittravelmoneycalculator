using BrexitTravelMoneyCalculator.Web.Api;
using BrexitTravelMoneyCalculator.Web.Data;
using BrexitTravelMoneyCalculator.Web.Data.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace BrexitTravelMoneyCalculator.Tests
{
    public class VerdictControllerTests
    {
        [Fact]
        public void Get_WhenNoCountryIsFound_Return404()
        {
            var dbService = Substitute.For<IDbService>();
            dbService.GetCountry(Arg.Any<string>()).Returns((Country)null);
            var controller = new VerdictController(dbService);

            var result = controller.Get(-1, "");

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_WhenNoCurrencyIsFound_Return404()
        {
            var dbService = Substitute.For<IDbService>();
            dbService.GetCountry(Arg.Any<string>()).Returns(new Country());
            dbService.GetCurrency(Arg.Any<string>()).Returns((Currency)null);
            var controller = new VerdictController(dbService);

            var result = controller.Get(-1, "");

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
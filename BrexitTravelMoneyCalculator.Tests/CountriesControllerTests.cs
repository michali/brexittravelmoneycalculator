using BrexitTravelMoneyCalculator.Web.Api;
using BrexitTravelMoneyCalculator.Web.Data;
using BrexitTravelMoneyCalculator.Web.Data.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace BrexitTravelMoneyCalculator.Tests
{
    public class CountriesControllerTests
    {
        private IDbService dbRepo;

        public CountriesControllerTests()
        {
            dbRepo = Substitute.For<IDbService>();
        }

        [Fact]
        public void Returns_Countries()
        {
            var controller = new CountriesController(dbRepo);
            dbRepo.GetCountries().ReturnsForAnyArgs(new Country[]{new Country()});
            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public void If_No_Countries_Returns_NoContent()
        {
            var controller = new CountriesController(dbRepo);
            dbRepo.GetCountries().ReturnsForAnyArgs(new Country[0]);

            var result = controller.Get();

            Assert.IsType<NoContentResult>(result);
        }
    }
}

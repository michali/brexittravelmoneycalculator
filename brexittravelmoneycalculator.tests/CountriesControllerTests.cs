using BrexitTravelMoneyCalculator.Web.Api;
using BrexitTravelMoneyCalculator.Web.Data;
using BrexitTravelMoneyCalculator.Web.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;

namespace Brexittravelmoneycalculator.Tests
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
        public void Returns_A_Country()
        {
            var controller = new CountriesController(dbRepo);
            dbRepo.GetCountries().ReturnsForAnyArgs(new Country[]{new Country(){Name="United Kingdom", Id="UK"}});

            var result = (OkObjectResult)controller.Get();

            Assert.Equal("United Kingdom", ((IEnumerable<Country>)result.Value).First().Name);
        }

        [Fact]
        public void If_No_Countries_Returns_404()
        {
            var controller = new CountriesController(dbRepo);
            dbRepo.GetCountries().ReturnsForAnyArgs(new Country[0]);

            var result = controller.Get();

            Assert.IsType<NotFoundResult>(result);
        }
    }
}

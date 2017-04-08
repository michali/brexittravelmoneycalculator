using BrexitTravelMoneyCalculator.Web.Api;
using BrexitTravelMoneyCalculator.Web.Data;
using BrexitTravelMoneyCalculator.Web.Data.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public void Returns_A_Country()
        {
            var controller = new CountriesController(dbRepo);
            dbRepo.GetCountries().ReturnsForAnyArgs(new Country[]{new Country(){Name="United Kingdom", Id="UK"}});

            var result = (OkObjectResult)controller.Get();

            Assert.Equal("United Kingdom", ((IEnumerable<Country>)result.Value).Single().Name);
            Assert.Equal("UK", ((IEnumerable<Country>)result.Value).Single().Id);
        }

        [Fact]
        public void Returns_Two_Countries()
        {
            var controller = new CountriesController(dbRepo);
            dbRepo.GetCountries().ReturnsForAnyArgs(new Country[]{
                new Country(){Name="United Kingdom", Id="UK"
                },
                new Country{Name="Ireland", Id="IE"}
                });

            var result = (OkObjectResult)controller.Get();

            Assert.Equal(2, ((IEnumerable<Country>)result.Value).Count());
            Assert.Equal("United Kingdom", ((IEnumerable<Country>)result.Value).First().Name);
            Assert.Equal("UK", ((IEnumerable<Country>)result.Value).First().Id);
            Assert.Equal("Ireland", ((IEnumerable<Country>)result.Value).Last().Name);
            Assert.Equal("IE", ((IEnumerable<Country>)result.Value).Last().Id);
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

using System;
using System.Collections.Generic;
using System.Linq;
using BrexitTravelMoneyCalculator.Web.Data.Models;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;

namespace BrexitTravelMoneyCalculator.Web.Data
{
    public class AzureDocumentDbService : IDataService
    {
        private readonly Conf conf;
        private readonly DocumentClient client;

        public AzureDocumentDbService(IConfiguration configuration)
        {
            conf = new Conf(configuration);
            client = new DocumentClient(new Uri(conf.GetEndpointUri()), conf.GetPrimaryKey());
        }
        public IEnumerable<Country> GetCountries()
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            return this.client.CreateDocumentQuery<Country>(
                UriFactory.CreateDocumentCollectionUri(conf.GetDatabaseName(), conf.GetCollectionName()), 
                queryOptions)
                .Where(c=>c.Type == "Country").AsEnumerable();
        }

        public object GetVerdict(string countryId)
        {
            var country = GetCountry(countryId);

            if (country == null)
            {
                return null;
            }

            var currency = GetCurrency(country.CurrencyId);

            if (currency == null)
            {
                return null;
            }

            return new 
            {
                Name = country.Name,
                Currency = new
                {
                    Code = currency.Code,
                    PreRefExchangeRate = currency.PreRefExchangeRate,
                    ExchangeRate = currency.ExchangeRate
                },
                LocalProduct = new 
                {
                    NameSingular = country.LocalProduct.NameSingular,
                    NamePlural = country.LocalProduct.NamePlural,
                    Price = country.LocalProduct.Price
                }
            };
        }

        private Country GetCountry(string countryId)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            return this.client.CreateDocumentQuery<Country>(
                UriFactory.CreateDocumentCollectionUri(conf.GetDatabaseName(), conf.GetCollectionName()), 
                queryOptions)
                .Where(c=>c.Id == countryId && c.Type == "Country").AsEnumerable().SingleOrDefault();
        }

        private Currency GetCurrency(string currencyId)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            return this.client.CreateDocumentQuery<Currency>(
                UriFactory.CreateDocumentCollectionUri(conf.GetDatabaseName(), conf.GetCollectionName()), 
                queryOptions)
                .Where(c=>c.Id == currencyId && c.Type == "Currency").AsEnumerable().SingleOrDefault();
        }
    }
}

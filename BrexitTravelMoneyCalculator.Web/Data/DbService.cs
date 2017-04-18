using System;
using System.Collections.Generic;
using System.Linq;
using BrexitTravelMoneyCalculator.Web.Data.Models;
using Microsoft.Azure.Documents.Client;

namespace BrexitTravelMoneyCalculator.Web.Data
{
    public class DbService : IDbService
    {
        private readonly Conf conf;
        private readonly DocumentClient client;

        public DbService()
        {
            conf = new Conf();
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

        public Country GetCountry(string countryId)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            return this.client.CreateDocumentQuery<Country>(
                UriFactory.CreateDocumentCollectionUri(conf.GetDatabaseName(), conf.GetCollectionName()), 
                queryOptions)
                .Where(c=>c.Id == countryId && c.Type == "Country").AsEnumerable().SingleOrDefault();
        }

        public Currency GetCurrency(string currencyId)
        {
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            return this.client.CreateDocumentQuery<Currency>(
                UriFactory.CreateDocumentCollectionUri(conf.GetDatabaseName(), conf.GetCollectionName()), 
                queryOptions)
                .Where(c=>c.Id == currencyId && c.Type == "Currency").AsEnumerable().SingleOrDefault();
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using BrexitTravelMoneyCalculator.Data.Models;
using System.Net;

namespace BrexitTravelMoneyCalculator.Data
{
    internal class CurrenciesClient
    {
        private DocumentClient client;
        private readonly Conf conf;
        private const string collectionName = "Currencies";
        public CurrenciesClient()
        {
            conf = new Conf();
            this.client = new DocumentClient(new Uri(conf.GetEndpointUri()), conf.GetPrimaryKey());
        }

        internal async Task SetupDocuments()
        { 
            await this.CreateDatabaseIfNotExists(conf.GetDatabaseName());
            await this.CreateDocumentCollectionIfNotExists(conf.GetDatabaseName(), collectionName);

            await this.CreateDocumentIfNotExists(
           new Currency
           {
               Id = "EUR",
               Code = "EUR",
               Name = "Euro",
               ExchangeRate = 1.16,
               PreRefExchangeRate = 1.31
           });

            await this.CreateDocumentIfNotExists(
            new Currency
            {
                Id = "USD",
                Code = "USD",
                Name = "US Dollar",
                ExchangeRate = 1.24,
                PreRefExchangeRate = 1.48
            });

            await this.CreateDocumentIfNotExists(
            new Currency
            {
                Id = "SEK",
                Code = "SEK",
                Name = "Swedish Krona",
                ExchangeRate = 11,
                PreRefExchangeRate = 12.21
            });

            await this.CreateDocumentIfNotExists(
            new Currency
            {
                Id = "AUD",
                Code = "AUD",
                Name = "Australian Dollar",
                ExchangeRate = 1.64,
                PreRefExchangeRate = 1.97
            });

            await this.CreateDocumentIfNotExists(
            new Currency
            {
                Id = "KRW",
                Code = "KRW",
                Name = "South Korean Won",
                ExchangeRate = 1454.43,
                PreRefExchangeRate = 1703.27
            });

            await this.CreateDocumentIfNotExists(
            new Currency
            {
                Id = "JPY",
                Code = "JPY",
                Name = "Japanese Yen",
                ExchangeRate = 141.82,
                PreRefExchangeRate = 155.77
            });

            await this.CreateDocumentIfNotExists(
            new Currency
            {
                Id = "CAD",
                Code = "CAD",
                Name = "Canadian Dollar",
                ExchangeRate = 1.65,
                PreRefExchangeRate = 1.9
            });

            await this.CreateDocumentIfNotExists(
            new Country
            {
                Id = "ES",
                Name = "Spain",
                CurrencyId = "EUR"
            });

            await this.CreateDocumentIfNotExists(
            new Country
            {
                Id = "CA",
                Name = "Canada",
                CurrencyId = "CAD"
            });

            await this.CreateDocumentIfNotExists(
            new Country
            {
                Id = "SE",
                Name = "Sweden",
                CurrencyId = "SEK"
            });

            await this.CreateDocumentIfNotExists(
            new Country
            {
                Id = "KR",
                Name = "South Korea",
                CurrencyId = "KRW"
            });

            await this.CreateDocumentIfNotExists(
            new Country
            {
                Id = "JP",
                Name = "Japan",
                CurrencyId = "JPY"
            });

            await this.CreateDocumentIfNotExists(
            new Country
            {
                Id = "US",
                Name = "United States of America",
                CurrencyId = "USD"
            });

            await this.CreateDocumentIfNotExists(
            new Metadata
            {
                Id = "metadata",
                LastUpdated = new DateTime(2017, 1, 20, 22, 34, 59)
            });
        }

        private async Task CreateDatabaseIfNotExists(string databaseName)
        {
            try
            {
                await this.client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseName));
                Console.WriteLine("Found {0}", databaseName);
            }
            catch (DocumentClientException de)
            {
                // If the database does not exist, create a new database
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDatabaseAsync(new Database { Id = databaseName });
                    Console.WriteLine("Created {0}", databaseName);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateDocumentCollectionIfNotExists(string databaseName, string collectionName)
        {
            try
            {
                await this.client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName));
                Console.WriteLine("Found {0}", collectionName);
            }
            catch (DocumentClientException de)
            {
                // If the document collection does not exist, create a new collection
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    DocumentCollection collectionInfo = new DocumentCollection();
                    collectionInfo.Id = collectionName;

                    // Optionally, you can configure the indexing policy of a collection. Here we configure collections for maximum query flexibility 
                    // including string range queries. 
                    collectionInfo.IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });

                    // DocumentDB collections can be reserved with throughput specified in request units/second. 1 RU is a normalized request equivalent to the read
                    // of a 1KB document.  Here we create a collection with 400 RU/s. 
                    await this.client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(databaseName),
                        new DocumentCollection { Id = collectionName },
                        new RequestOptions { OfferThroughput = 400 });

                    Console.WriteLine("Created {0}", collectionName);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task CreateDocumentIfNotExists(BrexitTravelMoneyCalculator.Data.Models.Document document)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(conf.GetDatabaseName(), collectionName, document.Id));
                Console.WriteLine("Found {0}", document.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(conf.GetDatabaseName(), collectionName), document);
                    Console.WriteLine("Created {0} {1}", document.GetType().Name, document.Id);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}

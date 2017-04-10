using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BrexitTravelMoneyCalculator.Web
{
    internal class Conf
    {
        private IConfigurationRoot configuration;

        internal Conf()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            configuration = builder.Build();
        }

        internal string GetEndpointUri()
        {
            return configuration["DatabaseConnection:endpointUri"];
        }

        internal string GetPrimaryKey()
        {
            return configuration["DatabaseConnection:key"];
        }

        internal string GetDatabaseName()
        {
            return configuration["DatabaseConnection:databaseName"];
        }

        internal string GetCollectionName()
        {
            return configuration["DatabaseConnection:collectionName"];
        }
    }
}

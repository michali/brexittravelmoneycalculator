using System;
using System.IO;
using System.Security;
using Microsoft.Extensions.Configuration;

namespace BrexitTravelMoneyCalculator.Data
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
            return configuration["endpointUri"];
        }

        internal string GetPrimaryKey()
        {
            return configuration["masterKey"];
        }

        internal string GetDatabaseName()
        {
            return configuration["databaseName"];
        }
    }
}

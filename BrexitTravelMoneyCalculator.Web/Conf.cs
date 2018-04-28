using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BrexitTravelMoneyCalculator.Web
{
    internal class Conf
    {
        public IConfiguration Configuration { get; }

        internal Conf(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        internal string GetEndpointUri()
        {
            return Configuration["DatabaseConnection:endpointUri"];
        }

        internal string GetPrimaryKey()
        {
            return Configuration["DatabaseConnection:key"];
        }

        internal string GetDatabaseName()
        {
            return Configuration["DatabaseConnection:databaseName"];
        }

        internal string GetCollectionName()
        {
            return Configuration["DatabaseConnection:collectionName"];
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatamaranTests.Utils
{
    public static class AppConfigurationBuilder
    {
        public static IConfigurationRoot Build()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"D:\Catamaran\Catamaran\Catamaran_API\appsettings.json")
            .Build();

            return configuration;
        }
    }
}

using Catamaran_API.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Catamaran_API.Models;
using System.Threading.Tasks;

namespace CatamaranTests
{
    [TestClass]
    public class DatabaseAccessTests
    {
        DatabaseAccessManager manager;

        public DatabaseAccessTests()
        {
            manager = new DatabaseAccessManager(ConfigurationBuilder());
        }

        [TestMethod]
        public async Task CheckDbConnection()
        {
            var model = new DataSearchModel()
            {
                TransactionId = new System.Guid("97934CEA16A448B784CF1BD5D02A5461")
            };
            var result = await manager.FetchTransaction(model);
            foreach (var item in result)
            {           
                Assert.AreEqual(item.Product, "Smart Watch");
            }
        }

        private static IConfigurationRoot ConfigurationBuilder()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"D:\Catamaran\Catamaran\Catamaran_API\appsettings.json")
            .Build();

            return configuration;
        }
    }
}

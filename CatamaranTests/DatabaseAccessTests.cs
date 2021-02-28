using Catamaran_API.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Catamaran_API.Models;
using System.Threading.Tasks;
using Catamaran_Models.Enums;
using FluentAssertions;

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
        public async Task GuidSearch()
        {
            var model = new DataSearchModel()
            {
                TransactionId = new System.Guid("97934CEA16A448B784CF1BD5D02A5461")
            };
            var result = await manager.FetchTransaction(model);

            result.Should()
                .Contain(x=> x.TransactionAmount == 5000
                && x.TransactionId == new System.Guid("97934CEA16A448B784CF1BD5D02A5461")
                && x.Vendor == "Amazon");
           
        }

        [TestMethod]
        public async Task MonthSearch()
        {
            var model = new DataSearchModel()
            {
                Month = Months.February
            };
            var result = await manager.FetchTransaction(model);

            result.Should().Contain(x => x.TransactionDate.Month == (int)Months.February);
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

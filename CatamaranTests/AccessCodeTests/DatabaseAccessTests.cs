using Catamaran_API.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Catamaran_API.Models;
using System.Threading.Tasks;
using Catamaran_Models.Enums;
using FluentAssertions;
using Catamaran_Models.Models;
using System;
using CatamaranTests.Utils;

namespace CatamaranTests
{
    [TestClass]
    public class DatabaseAccessTests
    {
        DatabaseAccessManager manager;

        public DatabaseAccessTests()
        {
            manager = new DatabaseAccessManager(AppConfigurationBuilder.Build());
        }

        [TestMethod]
        public async Task GuidSearch()
        {
            var model = new DataSearchModel()
            {
                TransactionId = new Guid("E1874D1AC8D34EF087571D6117D61506")
            };
            var result = await manager.FetchTransaction(model);

            result.Should()
                .Contain(x=> x.TransactionAmount == 5000
                && x.TransactionId == new System.Guid("E1874D1AC8D34EF087571D6117D61506")
                && x.Vendor == "Ajio"
                && x.PaymentMethod == PaymentModes.GooglePay);
           
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

        [TestMethod]
        public async Task InsertTransaction()
        {
            var model = new TransactionModel()
            {
                TransactionId = Guid.NewGuid(),
                TransactionAmount = 1200,
                TransactionDate = DateTime.Now,
                PaymentMethod = PaymentModes.Cash,
                Vendor = "Flip Kart",
                Product = "Mobile Phone"
            };

            var result = await manager.InsertTransaction(model);

            Assert.AreEqual(result, 1);
        }
    }
}

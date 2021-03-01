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

namespace CatamaranTests.Controllers
{
    [TestClass]
    public class ControllerTests
    {
        DatabaseAccessManager manager;

        public ControllerTests()
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
    }
}

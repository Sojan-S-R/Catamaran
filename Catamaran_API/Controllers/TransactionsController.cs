using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catamaran_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet("{id}")]
        public string GetTransaction(string transactionID)
        {
            return "value";
        }

        [HttpGet("{id}")]
        public string GetMonthly(int month)
        {
            return "value";
        }

        [HttpGet("{id}")]
        public string GetYearly(int year)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}

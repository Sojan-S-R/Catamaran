using Catamaran_API.DataAccess;
using Catamaran_Models.Enums;
using Catamaran_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catamaran_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private DatabaseAccessManager _manager { get; set; }

        public TransactionsController(DatabaseAccessManager manager)
        {
            _manager = manager;
        }

        [HttpGet("/TransactionId={transactionID}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TransactionModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTransaction(Guid transactionID)
        {
            var returnValue = await _manager.FetchTransaction
                (
                    new Models.DataSearchModel()
                    {
                        TransactionId = transactionID
                    }
                );
            if (returnValue != null)
                return Ok(returnValue);
            else
                return NotFound();
        }

        [HttpGet("/Month={month}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TransactionModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMonthly(int month)
        {
            var returnValue = await _manager.FetchTransaction
            (
                new Models.DataSearchModel()
                {
                    Month = (Months)month
                }
            );
            if (returnValue != null)
                return Ok(returnValue);
            else
                return NotFound();
        }

        [HttpGet("/Year={year}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TransactionModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetYearly(int year)
        {
            var returnValue = await _manager.FetchTransaction
            (
                new Models.DataSearchModel()
                {
                    Year = year
                }
            );
            if (returnValue != null)
                return Ok(returnValue);
            else
                return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TransactionModel model)
        {
            var returnValue = await _manager.InsertTransaction(model);
            if (returnValue != 0)
                return Ok();
            else
                return BadRequest();
        }
    }
}

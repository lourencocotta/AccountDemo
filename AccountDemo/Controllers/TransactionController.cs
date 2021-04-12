using AccountDemo.Dto;
using AccountDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Add new Transaction.
        /// </summary>
        /// <param name="transactionDto">Transaction data transfer object.</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add(TransactionAddDto transactionDto)
        {
            await _transactionService.AddAsync(transactionDto);

            return Ok();
        }

        /// <summary>
        /// Revere a Transaction.
        /// </summary>
        /// <param name="id">Transaction Id.</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Reverse(Guid id)
        {
            await _transactionService.ReverseAsync(id);

            return Ok();
        }

        /// <summary>
        /// Get the Account Balance.
        /// </summary>
        /// <param name="accountCode">Account code.</param>
        /// <returns></returns>
        [HttpGet("GetBalance")]
        public async Task<IActionResult> GetBalance(string accountCode)
        {
            var balance = await _transactionService.GetBalanceAsync(accountCode);

            return Ok(balance);
        }
    }
}

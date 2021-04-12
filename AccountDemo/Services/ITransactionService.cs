using AccountDemo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Services
{
    public interface ITransactionService
    {
        Task<decimal> GetBalanceAsync(string accountCode);

        Task AddAsync(TransactionAddDto transactionDto);

        Task ReverseAsync(Guid id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountDemo.Models;

namespace AccountDemo.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync(string accountCode);
        Task<Transaction> GetByIdAsync(Guid id);

        Task<Transaction> AddAsync(Transaction transaction);

        Task<Transaction> UpdateAsync(Transaction transaction);
        
    }
}

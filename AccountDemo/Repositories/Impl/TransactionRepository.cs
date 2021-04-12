using AccountDemo.Models;
using AccountDemo.Models.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Repositories.Impl
{
    public class TransactionRepository : ITransactionRepository
    {
        protected readonly AccountContext _accountContext;
        private readonly DbSet<Transaction> _dbSet;

        public TransactionRepository(AccountContext accountContext)
        {
            _accountContext = accountContext;
            _dbSet = accountContext.Set<Transaction>();
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            var addedEntity = (await _dbSet.AddAsync(transaction)).Entity;
            await _accountContext.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(string accountCode)
        {
            return await _dbSet.Include(x=>x.Account).Where(x=>x.Account.AccountCode.Equals(accountCode)).ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _dbSet.Where(x => x.TransactionId.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            _dbSet.Update(transaction);
            await _accountContext.SaveChangesAsync();

            return transaction;
        }

    }
}

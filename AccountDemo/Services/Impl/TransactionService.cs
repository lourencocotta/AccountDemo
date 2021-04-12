using AccountDemo.Dto;
using AccountDemo.Models;
using AccountDemo.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Services.Impl
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(TransactionAddDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            await _transactionRepository.AddAsync(transaction);
        }

        public async Task<decimal> GetBalanceAsync(string accountCode)
        {
            var transactions = await _transactionRepository.GetAllAsync(accountCode);

            return transactions.Where(x => !x.IsReversed).Sum(x => x.Amount);
        }

        public async Task ReverseAsync(Guid id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            
            transaction.IsReversed = true;

            await _transactionRepository.UpdateAsync(transaction);
        }
    }
}

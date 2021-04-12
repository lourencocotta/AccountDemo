using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Models.Persistence
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            var account = new Account
            {
                Id =1 , AccountCode="code 1"
            };
            modelBuilder.Entity<Account>().HasData(account);

            var customers = new List<Transaction>
            {
                new Transaction { TransactionId = Guid.NewGuid(), Description= "Test 1" , TransactionDate= DateTime.Now, Amount= (decimal)100, FromPayee="from test 1", AccountId = 1 },
                new Transaction { TransactionId = Guid.NewGuid(), Description= "Test 2" , TransactionDate= DateTime.Now, Amount= (decimal)-50, FromPayee="from test 2", AccountId = 1 },
            };

            modelBuilder.Entity<Transaction>().HasData(customers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string FromPayee { get; set; }
        public bool IsReversed { get; set; }
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }

    }
}

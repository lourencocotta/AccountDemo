using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Dto
{
    public class TransactionDto
    {
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string FromPayee { get; set; }
        public bool IsReversed { get; set; }
        public int AccountId { get; set; }
    }
}

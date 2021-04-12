using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Dto
{
    public class TransactionAddDto
    {
        /// <summary>
        /// Transaction Id
        /// </summary>
        public Guid TransactionId { get; set; }
        /// <summary>
        /// Transaction date
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// From payee
        /// </summary>
        public string FromPayee { get; set; }
        /// <summary>
        /// Account Id (1)
        /// </summary>
        public int AccountId { get; set; }
    }
}

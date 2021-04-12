using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountDemo.Models
{
    [Table("Accounts")]
    public class Account
    {
        public int Id { get; set; }
        public string AccountCode { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}

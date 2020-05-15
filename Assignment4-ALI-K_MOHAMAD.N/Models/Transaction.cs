using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment4_ALI_K_MOHAMAD.N.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public CheckingAccount CheckingAccount { get; set; }
        public int CheckingAccountId { get; set; }

        public DateTime TransactionDate { get; set; }
        public String TransactionSource { get; set; }
    }
}
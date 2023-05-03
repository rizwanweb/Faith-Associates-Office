using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Accounts
{
    public class AccountLedger
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ClientID { get; set; }
        public string Particular { get; set; }
        public int Debit { get; set; }
        public int Credit { get; set; }
        public int Reff { get; set; }
        public string drcr { get; set; }
    }
}

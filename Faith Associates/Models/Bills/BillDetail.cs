using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Bills
{
    public class BillDetail
    {
        public int BillDetailsID { get; set; }
        public int BillID { get; set; }
        public string Particulars { get; set; }
        public string ReceiptNo { get; set; }
        public int ByYou { get; set; }
        public int ByUs { get; set; }
    }
}

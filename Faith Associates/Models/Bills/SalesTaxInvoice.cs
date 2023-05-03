using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Bills
{
    public class SalesTaxInvoice
    {
        public int STID { get; set; }
        public int SalesTaxNo { get; set; }
        public DateTime STDate { get; set; }
        public int BillID { get; set; }
        public double Rate { get; set; }
        public int SalesTax { get; set; }
    }
}

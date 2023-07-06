using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Bills
{
    public class Billl
    {
        public int BillID { get; set; }
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public int JobID { get; set; }
        public int SubTotal { get; set; }
        public int ServiceCharges { get; set; }
        public double SalesTaxRate { get; set; }
        public int SalesTax { get; set; }
        public int Total { get; set; }
		public string Note { get; set; }
    }
}

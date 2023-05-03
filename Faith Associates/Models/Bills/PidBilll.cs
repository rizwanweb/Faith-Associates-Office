using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Bills
{
    public class PidBilll
    {
        public int BillID { get; set; }
        public int BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public int PidID { get; set; }
        public int SubTotal { get; set; }
        public int ServiceCharges { get; set; }
        public int Total { get; set; }
    }
}

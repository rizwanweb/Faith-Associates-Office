using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Items
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string HSCode { get; set; }
        public double CustomDuty { get; set; }
        public double AddCustomDuty { get; set; }
        public double SalesTax { get; set; }
        public double IncomeTax { get; set; }
        public double Cess { get; set; }
        public double RD { get; set; }
        public int CustomDutyType { get; set; }
        public int AddCustomDutyType { get; set; }
        public int CessType { get; set; }
        public int RDType { get; set; }
    }
}

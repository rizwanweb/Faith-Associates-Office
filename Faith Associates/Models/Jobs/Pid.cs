using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Jobs
{
    public class Pid
    {
        public int PidID { get; set; }
        public int PidNo { get; set; }
        public DateTime PidDate { get; set; }
        public int Client { get; set; }
        public string LC { get; set; }
        public DateTime LCDate { get; set; }
        public int Item { get; set; }
        public string ItemDetail { get; set; }
        public int Containers { get; set; }
        public int Size { get; set; }
        public string Packages { get; set; }
        public string Vessel { get; set; }
        public string BL { get; set; }
        public DateTime BLDate { get; set; }
        public int IGM { get; set; }
        public DateTime IGMDate { get; set; }
        public int IndexNo { get; set; }
        public int Quantity { get; set; }
        public double InvoiceValueUSD { get; set; }
        public double ExchangeRate { get; set; }
        public int ValueInPKR { get; set; }
        public int Insurance { get; set; }
        public int LandingCharges { get; set; }
        public int ImportValuePKR { get; set; }
        public int CustomDuty { get; set; }
        public string CustomDutyType { get; set; }
        public double CustomDutyRate { get; set; }
        public int AddCustomDuty { get; set; }
        public string AddCustomDutyType { get; set; }
        public double AddCustomDutyRate { get; set; }
        public int SalesTax { get; set; }
        public string SalesTaxType { get; set; }
        public double SalesTaxRate { get; set; }
        public int IncomeTax { get; set; }
        public string IncomeTaxType { get; set; }
        public double IncomeTaxRate { get; set; }
        public int Cess { get; set; }
        public string CessType { get; set; }
        public double CessRate { get; set; }
        public int RD { get; set; }
        public string RDType { get; set; }
        public double RDRate { get; set; }
        public int TotalDuty { get; set; }
        public int Terminal { get; set; }
        public int ShippingLine { get; set; }
        public int Lolo { get; set; }
        public string GD { get; set; }
        public DateTime GDDate { get; set; }
        public string Cash { get; set; }
        public DateTime CashDate { get; set; }
    }
}

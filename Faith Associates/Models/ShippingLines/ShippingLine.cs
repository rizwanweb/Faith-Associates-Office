using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.ShippingLines
{
    public class ShippingLine
    {
        public int ShippingLineID { get; set; }
        public string ShippingLineName { get; set; }
        public string ShortName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

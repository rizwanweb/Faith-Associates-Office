using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.PSQC
{
    public class Certificate
    {
        public int PSQCID { get; set; }
        public int JobID { get; set; }
        public string Invoice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Origin { get; set; }
        public string Brand { get; set; }
        public int AuthorizedPerson { get; set; }
    }
}

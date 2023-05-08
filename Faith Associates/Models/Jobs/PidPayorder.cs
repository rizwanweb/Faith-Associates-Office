using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Jobs
{
    public class PidPayorder
    {
        public int PayorderID { get; set; }
        public int PidID { get; set; }
        public string Particular { get; set; }
        public int Amount { get; set; }
        public string Detail { get; set; }
    }
}

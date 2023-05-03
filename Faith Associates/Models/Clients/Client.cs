using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith_Associates.Models.Clients
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NTN { get; set; }
        public string GST { get; set; }
        public string Address { get; set; }
        public int City { get; set; }
        public int ClientType { get; set; }
        public string StandAddress { get; set; }
        public string Fax { get; set; }
    }
}

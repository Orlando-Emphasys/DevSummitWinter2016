using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRScanner_API.Models
{
    public class Office
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}

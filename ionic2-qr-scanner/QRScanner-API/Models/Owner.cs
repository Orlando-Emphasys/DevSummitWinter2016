using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRScanner_API.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public int LocationID { get; set; }

        public int OfficeID { get; set; }

    }
}

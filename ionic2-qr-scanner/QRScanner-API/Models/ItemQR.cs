using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRScanner_API.Models
{
    public class ItemQR
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public string SerialNumber { get; set; }

        public int OwnerID { get; set; }

        public DateTime AssignedDate { get; set; }
        public DateTime? EndDate { get; set; }


    }
}

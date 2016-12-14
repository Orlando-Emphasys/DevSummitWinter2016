using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRScanner_API.ViewModels
{
    public class NewItemViewModel
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string type { get; set; }
        public string city { get; set; }
        public string ownername { get; set; }
        public string location { get; set; }
        public string serialnumber { get; set; }
    }
}

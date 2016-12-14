﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRScanner_API.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int OfficeId { get; set; }

    }
}

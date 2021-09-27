﻿using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardealership.Shared.Queries
{
    public class InventoryReport
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
        public string Condition { get; set; }

    }
}

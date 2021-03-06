﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MileageTracker.Models
{
    public class Trip : Expense
    {
        public string Destination { get; set; }
        public decimal BeginMileage { get; set; }
        public decimal EndMileage { get; set; }
        public decimal Fee { get; set; }
        public string FeeDescription { get; set; }
    }
}

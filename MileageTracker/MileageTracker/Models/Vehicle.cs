﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MileageTracker.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }

        [Obsolete]
        public int UserID { get; set; }
        public string UserGUID { get; set; }

        public string Name { get; set; }

    }
}

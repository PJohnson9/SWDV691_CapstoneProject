using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MileageTracker.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

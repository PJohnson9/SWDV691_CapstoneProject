using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileageTracker.Models
{
    public class Trip : Expense
    {
        public string Destination { get; set; }
        public decimal BeginMileage { get; set; }
        public decimal EndMileage { get; set; }
        public decimal Fee { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public string FeeDescription { get; set; }
    }
}

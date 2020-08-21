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
        [Display(Name = "Vehicle")]
        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
        public string Destination { get; set; }

        [Column(TypeName = "decimal(18, 1)")] 
        public decimal BeginMileage { get; set; }

        [Column(TypeName = "decimal(18, 1)")] 
        public decimal EndMileage { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Fee { get; set; }

        public string FeeDescription { get; set; }


        public decimal TotalMileage { get { return (EndMileage - BeginMileage); } }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal ComputedExpense { get { return (TotalMileage * Rate.PerMile); } }
    }
}

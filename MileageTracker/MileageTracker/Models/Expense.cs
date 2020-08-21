using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MileageTracker.Models
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Amount { get; set; }
    }
}

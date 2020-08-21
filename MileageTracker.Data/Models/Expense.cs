using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MileageTracker.Models
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public int ProjectID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Decimal Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileageTracker.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        [Display(Name = "Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }

    }
}

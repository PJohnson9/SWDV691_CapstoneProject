using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MileageTracker.Models
{
    public class Client
    {
        public int ClientID { get; set; }

        [Obsolete]
        public int UserID { get; set; }
        public string UserGUID { get; set; }
        public string Name { get; set; }
        

        //public IEnumerable
    }
}

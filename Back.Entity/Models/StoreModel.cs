using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Entity.Models
{
    public class StoreModel
    {
        public int idStore { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
    }
}

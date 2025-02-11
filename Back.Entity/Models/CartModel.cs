using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Entity.Models
{
    public class CartModel
    {
        public int IdCart { get; set; }
        public int IdItem { get; set; }
        public int IdCustomer { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}

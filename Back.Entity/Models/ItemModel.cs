using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Entity.Models
{
    public class ItemModel
    {
        public int idItem { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public string Image { get; set;}
    }
}

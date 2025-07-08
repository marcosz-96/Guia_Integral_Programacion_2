using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class ItemFactura
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; } // Cantidad 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class FacturaCalculator
    {
        public double CalculateTotal(Factura factura)
        {
            double total = 0;

            foreach (var item in factura.Items)
            {
                total += item.Price * item.Amount; 
            }

            return total;
        }
    }
}

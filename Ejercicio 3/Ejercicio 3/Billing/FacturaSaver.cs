using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class FacturaSaver
    {
        private List<Factura> facturasSaves = new List<Factura>();

        public void SaveFactura(Factura factura)
        {
            facturasSaves.Add(factura);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"The invoice N°: {factura.Number} was saved succefully");
            Console.WriteLine("--------------------------------------------------------");
            Console.ReadKey();
        }

        public List<Factura> GetFacturas()
        {
            return facturasSaves;
        }
    }
}

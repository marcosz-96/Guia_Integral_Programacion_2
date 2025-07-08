using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class FacturaPrinterDigital : IDigitalPrinter
    {
        public void PrintOnPaper(Factura factura)
        {
            Console.WriteLine("\n=== Invoid Digital ===");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Invoid Electronic: {factura.Number} generate electronically.");
            Console.WriteLine($"Send to: {factura.Client} per email.");
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}

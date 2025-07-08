using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interface;

namespace Billing
{
    public class FacturaPrinterPaper : IPaperPrinter
    {
        public void PrintToConsole(Factura factura)
        {
            Console.WriteLine("\n=== Printed Invoid Console ===");
            factura.ViewData();
            Console.WriteLine("\nItems");
            foreach (var item in factura.Items)
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine($"Description: {item.Description} | Amount: {item.Amount} | Price: {item.Price}");
                Console.WriteLine("------------------------------------------------------------------------------");
            }

            var calculator = new FacturaCalculator();
            Console.WriteLine("\n------------------------------------------------------------------------------");
            Console.WriteLine($"\nTotal: {calculator.CalculateTotal(factura):USD}");
            Console.WriteLine("------------------------------------------------------------------------------");
        }
    }
}

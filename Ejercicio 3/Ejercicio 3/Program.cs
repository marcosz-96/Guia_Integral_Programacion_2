using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing;
using ManagerInvoices;

namespace Ejercicio_3
{
    public class Program
    {
        static void Main()
        {
            Console.Title = "Billing System";
            var manager = new ManagerInvoice(
            new FacturaSaver(),
            new FacturaCalculator(),
            new FacturaPrinterPaper(),
            new FacturaPrinterDigital());

            manager.MainMenu();
        }
    }
}

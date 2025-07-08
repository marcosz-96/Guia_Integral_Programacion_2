using Billing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class Factura
    {
        public string Number { get; set; }
        public string Client {  get; set; }
        public DateTime Date { get; set; }
        public List<ItemFactura> Items { get; set; } = new List<ItemFactura>();

        // Mostramos los datos básicos de las facturas
        public void ViewData()
        {
            Console.WriteLine($"Factura N°: {Number}");
            Console.WriteLine($"Client: {Client}");
            Console.WriteLine($"Date: {Date.ToShortDateString()}");
        }
    }
}

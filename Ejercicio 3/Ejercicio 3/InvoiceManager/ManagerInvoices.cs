using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Billing;
using Interface;

namespace ManagerInvoices
{
    public class ManagerInvoice
    {
        // Se instancian las dependencias
        private readonly FacturaSaver _facturaSaver;
        private readonly FacturaCalculator _facturaCalculator;
        private readonly IPaperPrinter _paperPrinter;
        private readonly IDigitalPrinter _digitalPrinter; 
        
        // Se inicializan las dependencias en el Constructor
        public ManagerInvoice(
            FacturaSaver facturaSaver,
            FacturaCalculator facturaCalculator,
            IPaperPrinter paperPrinter,
            IDigitalPrinter digitalPrinter)
        {
            _facturaSaver = facturaSaver;
            _facturaCalculator = facturaCalculator;
            _paperPrinter = paperPrinter;
            _digitalPrinter = digitalPrinter;
        }

        private string Input(string msg)
        {
            Console.Write($"{msg}");
            return Console.ReadLine();
        }

        private void CreateNewFactura()
        {
            var factura = new Factura
            {
                Number = Input("Invoice Number: "),
                Client = Input("Client: "),
                Date = DateTime.Now
            };

            Console.WriteLine("\n=== Add items ====");
            while (true)
            {
                var descriptions = Input(">>>>> Descriptions item <<<<<");
                
                while(string.IsNullOrEmpty(descriptions))
                {
                    Console.WriteLine("[ALERT] The description cannot be empty.");
                    Console.Write("Add description: ");
                    descriptions = Input("");
                }

                factura.Items.Add(new ItemFactura
                {
                    Description = descriptions,
                    Price = double.Parse(Input("Unit price")),
                    Amount = int.Parse(Input("Amount"))
                });

                _facturaSaver.SaveFactura(factura);
                Console.WriteLine("\n¡Invoice created successfully!");
                Console.ReadKey();
            }
        }

        private void ListFactura()
        {
            var facturas = _facturaSaver.GetFacturas();

            if (!facturas.Any())
            {
                Console.WriteLine("[ALERT] There are no invoice registered.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("\n=== Registered Invoices ===");
                foreach (var f in facturas)
                {
                    Console.WriteLine("-----------------------------------------------");
                    f.ViewData();
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine($"Total: {_facturaCalculator.CalculateTotal(f):USD}");
                    Console.WriteLine("-----------------------------------------------");
                }
            }
            Console.ReadKey(); 
        }

        private Factura SelectFactura()
        {
            ListFactura();
            var numberInvoice = Input("Enter the invoice number: ");
            return _facturaSaver.GetFacturas().Find(f=> f.Number.Equals(numberInvoice));
        }

        private void CalculateTotalFactura()
        {
            var factura = SelectFactura();
            Console.WriteLine(factura != null ? $"Total the invoice N° {factura.Number}: {_facturaCalculator.CalculateTotal(factura):USD}" 
                : "Invoice not found.");
            Console.ReadKey();
            return;
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== BILLING SYSTEM ===");
                Console.WriteLine("\n-------------------------------");
                Console.WriteLine("1: Create new invoice"); // Crear una nueva factura
                Console.WriteLine("2: Print invoice"); // Lleva al submenu de impresión de las facturas
                Console.WriteLine("3: List invoice"); // Listar las facturas cargadas
                Console.WriteLine("4: Calculate total invoice"); // Calcular el total de una factura
                Console.WriteLine("5: End");
                Console.WriteLine("-------------------------------");

                try
                {
                    Console.Write("\nOption: ");
                    int options = int.Parse(Console.ReadLine());

                    while (options < 1 || options > 5)
                    {
                        Console.WriteLine("[ALERT] Option invalid.");
                        Console.Write("\nEnter 'm' to return to the menu: ");
                        string option = Console.ReadLine().ToLower();

                        switch (option)
                        {
                            case "m":
                                MainMenu();
                                break;
                        }
                    }

                    switch (options)
                    {
                        case 1:
                            CreateNewFactura();
                            break;
                        case 2:
                            PrintMenu();
                            break;
                        case 3:
                            ListFactura();
                            break;
                        case 4:
                            CalculateTotalFactura();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERROR] Opcion Invalida: {ex.Message}");
                    Console.ResetColor();
                    Console.Write("\n'Enter' to return to the menu: ");
                    Console.ReadKey();
                }    
            }
        }

        private void PrintMenu() // Submenu de distintos tipos de impresiones
        {
            var factura = SelectFactura(); // Selecciona una factura para imprimir
            if (factura == null) // En caso de que no hayan facturas se sale de la opcion
            {
                Console.WriteLine("[ALERT] There are no invoice charged.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("--- PRINT MENU ---");
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("1. Print on console"); // Imprimir por consola
            Console.WriteLine("2. Digital printing"); // Imprimir Digitalmente
            Console.WriteLine("3. Return to the main menu"); // Vuelve al menu principal
            Console.WriteLine("--------------------------------");
            Console.Write("\nSelect option: ");
            try
            {
                int opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("------------------------------");

                while (opcion < 1 || opcion > 3) // Ne caso de opcion invalida
                {
                    Console.WriteLine("[ALERT] Option invalid.");
                    Console.Write("\nEnter 'm' to return to the menu: ");
                    string opcions = Console.ReadLine().ToLower();

                    switch (opcions)
                    {
                        case "m":
                            MainMenu();
                            break;
                    }
                }

                switch (opcion)
                {
                    case 1:
                        _paperPrinter.PrintToConsole(factura); // Imprime digitalmente
                        break;
                    case 2:
                        _digitalPrinter.PrintOnPaper(factura); // Imprime en papel
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR] Opcion Invalida: {ex.Message}");
                Console.ResetColor();
                Console.Write("\n'Enter' to return to the menu: ");
                Console.ReadKey();
            }
        }
    }
}

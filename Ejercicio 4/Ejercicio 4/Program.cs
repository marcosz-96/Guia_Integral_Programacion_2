using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Products;

namespace Ejercicio_4
{
    internal class Program
    {
        static void Main()
        {
            ProductCRUD pC = new ProductCRUD(); // Product CRUD

            Console.Title = "Hardware System";
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("--- Welcome to Product Management ---");
                Console.WriteLine("------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("1. Load Product");
                Console.WriteLine("2. View Product List");
                Console.WriteLine("3. Remove a Product from the List");
                Console.WriteLine("4. Update a Product from the List");
                Console.WriteLine("5. End");
                Console.WriteLine("\n------------------------------------------");
                Console.Write("Option: ");
                Console.ForegroundColor = ConsoleColor.White;

                try
                {
                    int opcion;

                    while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
                    {
                        Console.WriteLine("[ERROR] Option invalid.");
                        Console.Write("\nEnter 'm' to return to the menu: ");
                        string option = Console.ReadLine().ToLower();

                        switch (option)
                        {
                            case "m":
                                Main();
                                break;
                        }
                    }

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            pC.LoadProducts();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            pC.ViewProductList();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            pC.DeleteProduct();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            pC.UpdateProduct();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("¡Hasta luego!");
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR] Option Invali: {ex.Message}");
                    Console.ResetColor();
                    Console.Write("\n'Enter' to return to the menu: ");
                    Console.ReadKey();
                }   
            }
        }
    }
}

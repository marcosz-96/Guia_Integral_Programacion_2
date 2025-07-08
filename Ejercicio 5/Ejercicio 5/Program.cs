using System;
using Initialization;

namespace Ejercicio_5
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Library Management";

            // Se inicializa toda la aplicación
            Initializations.InitApplication();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                Console.WriteLine("   ==== LIBRARY MANAGEMENT ====    ");
                Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                Console.WriteLine("1. Manage Books");
                Console.WriteLine("2. Manage Users");
                Console.WriteLine("3. Manage Loans");
                Console.WriteLine("4. END");
                Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                Console.Write("Enter an option: ");
                Console.ForegroundColor= ConsoleColor.White;
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Initializations.BooksController.ShowMenuBook();
                            break;
                        case "2":
                            Console.Clear();
                            Initializations.UsersController.ShowMenuUser();
                            break;
                        case "3":
                            Console.Clear();
                            Initializations.LoansController.ShowMenuLoans();
                            break;
                        case "4":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("End");
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR]: {ex.Message}");
                    Console.ResetColor();
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}

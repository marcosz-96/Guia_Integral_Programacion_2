using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Municipality;

namespace Ejercicio_1
{
    public class Program
    {
        public static void Main()
        {
            Console.Title = "Municipality";

            Citizens citizens = new Citizens();
            
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("¡Welcome to the program!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n1: Add data.");
                Console.WriteLine("2: Greet.");
                Console.WriteLine("3: Exit.");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\nOpcion: ");
                Console.ForegroundColor = ConsoleColor.White;
                string opcion = Console.ReadLine();

                do
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            citizens.AddCitizens();
                            break;
                        case "2":
                            Console.Clear();
                            citizens.GreetCitizens();
                            break;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("End.");
                            Console.ReadKey();
                            break;
                    }
                } while (opcion == "3");
            }
        }
    }
}

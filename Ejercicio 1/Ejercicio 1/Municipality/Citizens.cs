using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Municipality
{
    public class Citizens
    {
        private string Name { get; set; }
        private string LastName { get; set; }
        private string DNI { get; set; }
        private int Age { get; set; }

        public Citizens(string name, string lastName, string dni, int age)
        {
            this.Name = name;
            this.LastName = lastName;
            this.DNI = dni;
            this.Age = age;
        }

        public Citizens() { }

        // Lista para guardar los datos cargados
        List<Citizens> citizensList = new List<Citizens>();

        public void GreetCitizens() // Saludar al ciudadano
        {

            if (citizensList.Count == 0 || citizensList == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Sorry, there is no aggregated data.");
                Console.ReadKey();
                Console.ResetColor();
            }
            else
            {
                foreach (var c in citizensList)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("############################################################");
                    Console.WriteLine($"Hello {c.Name}, his age is: {c.Age}");
                    if (c.Age >= 18)
                    {
                        Console.ForegroundColor= ConsoleColor.DarkGreen;
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine("Adult citizens.");
                        Console.WriteLine("------------------------------------------------------------");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine("Is a minor.");
                        Console.WriteLine("------------------------------------------------------------");
                    }
                    Console.WriteLine("############################################################");
                }
                Console.ReadKey();
                Console.ResetColor();
            }
        }

        public void AddCitizens() // Añadir datos
        {
            string input;

            do
            {
                Console.Write("Citizen Name: ");
                string name = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("DNI: ");
                string dni = Console.ReadLine();
                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                // Validacion de edad

                while (age < 0)
                {
                    Console.WriteLine("[ALERT]: Age must be greater than zero.");
                    Console.Write("Enter an age: ");
                    age = int.Parse(Console.ReadLine());
                }

                citizensList.Add(new Citizens(name, lastName, dni, age));
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n¡Data loaded successfully!");
                Console.ReadKey();
                Console.ResetColor();

                Console.Write("Add more data? (y/n): ");
                input = Console.ReadLine().ToLower();
            } while (input == "y");
        }
    }
}

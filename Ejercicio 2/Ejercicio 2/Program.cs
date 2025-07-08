using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinarian;

namespace Ejercicio_2
{
    internal class Program
    {
        public static void Main()
        {
            Console.Title = "¡Veterinarian!";

            Cat cat = new Cat("Tito");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(cat.Presentation());
            Console.WriteLine($"My cat says: {cat.MakeSound()}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------");
            Dog dog = new Dog("Ruffus");
            Console.WriteLine($"My dog´s name is {dog.Name} and he says {dog.MakeSound()}");

            Console.ReadKey();
        }
    }
}

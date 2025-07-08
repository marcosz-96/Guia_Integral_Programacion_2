using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Veterinarian
{
    public class Cat : Animals
    {
        public Cat(string name) : base(name) { }

        public Cat() { }

        public override string MakeSound()
        {
            return "¡MIAU!";
        }

        public string Presentation()
        {
            return $"Hi! I have a cat, his name is {Name} and hi does ¡MIAU!";
        }
    }
}

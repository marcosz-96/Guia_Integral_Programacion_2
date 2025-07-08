using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinarian
{
    public class Dog : Animals
    {
        public Dog (string name) : base (name) { }

        public Dog() { }

        public override string MakeSound()
        {
            return "¡GUAU!";
        }
    }
}

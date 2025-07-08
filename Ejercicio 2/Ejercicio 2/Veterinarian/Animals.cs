using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinarian
{
    public class Animals
    {
        public string Name { get; set; }

        public Animals(string name)
        {
            this.Name = name;
        }
        public Animals() { }

        public virtual string MakeSound() // Emitir sonido
        {
            return "";
        }
    }
}

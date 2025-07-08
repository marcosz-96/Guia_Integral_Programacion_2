using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Billing;

namespace Interface
{
    public interface IDigitalPrinter
    {
        void PrintOnPaper(Factura factura);
    }
}

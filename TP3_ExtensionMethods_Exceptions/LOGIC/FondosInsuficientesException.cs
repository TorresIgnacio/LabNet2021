using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class FondosInsuficientesException : Exception
    {
        public FondosInsuficientesException() : base("El usuario no tiene los fondos suficientes para realizar la transaccion")
        {

        }
    }
}

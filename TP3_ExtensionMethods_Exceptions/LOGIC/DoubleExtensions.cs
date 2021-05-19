using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public static class DoubleExtensions
    {
        public static double ValorAbsoluto(this double numero)
        {
            if (numero >= 0)
                return numero;
            else
                return (numero * (-1));
        }
    }
}

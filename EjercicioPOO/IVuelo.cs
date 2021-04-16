using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    interface IVuelo
    {
        int VelocidadAerea { get; set; }
        string Despegar();
        string Aterrizar();
    }
}

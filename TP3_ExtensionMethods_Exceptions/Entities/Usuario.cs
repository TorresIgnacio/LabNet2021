using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario
    {
        public string nombre;
        public uint id;
        public double saldoBancario;

        public Usuario(uint id, string nombre)
        {
            this.nombre = nombre;
            saldoBancario = 0;
            this.id = id;
        }

        public Usuario(uint id, string nombre, double saldoBancario)
        {
            this.nombre = nombre;
            this.saldoBancario = saldoBancario;
            this.id = id;
        }
    }
}

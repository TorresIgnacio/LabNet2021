using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Usuario
    {
        public string nombre;
        private double id;
        private double saldoBancario;
        private static double numeroUsuarios = 0;

        public Usuario()
        {
            nombre = "SinNombre";
            saldoBancario = 0;
            id = numeroUsuarios;
            numeroUsuarios++;
        }
        public Usuario(string nombre)
        {
            this.nombre = nombre;
            saldoBancario = 0;
            id = numeroUsuarios;
            numeroUsuarios++;
        }

        public Usuario(string nombre, double saldoBancario)
        {
            this.nombre = nombre;
            this.saldoBancario = saldoBancario;
            id = numeroUsuarios;
            numeroUsuarios++;
        }

        public void ModificarSaldo(double monto)
        {
            saldoBancario += monto;
            return;
        }

        public double GetId()
        {
            return id;
        }
    }
}

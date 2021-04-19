using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Database
    {
        private static Usuario usuario1 = new Usuario("Usuario1", 250000);
        private static Usuario usuario2 = new Usuario("Usuario2");

        public static void ModificarSaldoUsuario(double monto, double id)
        {
            if (id == usuario1.GetId())
            {   
                usuario1.ModificarSaldo(monto);
                return;
            }
            if (id == usuario2.GetId())
            {
                usuario2.ModificarSaldo(monto);
                return;
            }
            return;
        }
    }
}

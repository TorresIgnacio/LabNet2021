using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace LOGIC
{
    public class OperacionesBancarias
    {
        private static double montoMaximo = 100000;
        //Transfiere un monto de la cuenta del usuario 1 al usuario 2 pero no se puede transmitir mas de x monto
        public static bool Transferencia(double id1, double id2, double monto)
        {
            if (monto > montoMaximo)
            {
                throw new ArgumentOutOfRangeException("monto", $"No se puede transferir mas de {montoMaximo} por operacion");   
            }

            if (monto < 0 )
            {
                throw new ArgumentOutOfRangeException("monto", "La transaccion no puede ser menor a cero");
            }

            else
            {
                Database.ModificarSaldoUsuario(-monto, id1);
                Database.ModificarSaldoUsuario(monto,id2);
                return true;
            }
        }
    }
}

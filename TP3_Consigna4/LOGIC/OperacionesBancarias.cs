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
        //Transfiere un monto de la cuenta del usuario 1 al usuario 2 pero no se puede transmitir mas de montoMaximo
        public static bool Transferencia(double id1, double id2, double monto)
        {
            //Se comprueba que existan las id (hardcodeado)
            switch (id1)
            {
                case 0:
                case 1:
                    break;
                default:
                    throw new UsuarioIdException();
            }

            switch (id2)
            {
                case 0:
                case 1:
                    break;
                default:
                    throw new UsuarioIdException();
            }

            if (monto > montoMaximo)
            {
                throw new ArgumentException($"No se puede transferir mas de {montoMaximo} por operacion");
            }
            else
            {
                Database.ModificarSaldoUsuario(-monto, id1);
                Database.ModificarSaldoUsuario(monto, id2);
                return true;
            }
        }
    }
}

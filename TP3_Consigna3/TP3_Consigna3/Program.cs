using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC;

namespace TP3_Consigna3
{
    class Program
    {
        //Funcion Transferencia transfiere un monto de la cuenta del usuario 1 al usuario 2 pero no se puede transmitir mas de montoMaximo (100.000)
        //La misma acepta 2 ID de usuario  y un monto, el primer usuario transfiere al segundo el monto provisto
        //Solamente existen 2 ID de usuario que son '0' y '1' (En consigna 4 se trabaja sobre esto)
        //No se comprueba que la cuenta emisora tenga los fondos necesarios
        static void Main(string[] args)
        {
            try
            {
                //Prueba con monto mayor a monto maximo
                OperacionesBancarias.Transferencia(0, 1, 133000);
                Console.WriteLine("La transaccion fue un exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
                Console.WriteLine("La transaccion no pudo llevarse a cabo");
            }

            Console.Write("\n\n");
            try
            {
                //Prueba con monto menor a 0
                OperacionesBancarias.Transferencia(0, 1, -63000);
                Console.WriteLine("La transaccion fue un exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
                Console.WriteLine("La transaccion no pudo llevarse a cabo");
            }
            Console.Write("\n\n");
            try
            {
                //Prueba con monto correcto
                OperacionesBancarias.Transferencia(0, 1, 63000);
                Console.WriteLine("La transaccion fue un exito");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
                Console.WriteLine("La transaccion no pudo llevarse a cabo");
            }
            Console.ReadLine();



        }
    }
}

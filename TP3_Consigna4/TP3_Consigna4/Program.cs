using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOGIC;


namespace TP3_Consigna4
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                try
                {
                    //Funcion Transferencia acepta 2 ID de usuario  y un monto, el primer usuario transfiere al segundo el monto provisto
                    //Solamente existen 2 ID de usuario que son '0' y '1', si se intenta otra el programa arrojara la custom exception UsuarioIdException
                    OperacionesBancarias.Transferencia(3, 1, 12000);                  
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
}

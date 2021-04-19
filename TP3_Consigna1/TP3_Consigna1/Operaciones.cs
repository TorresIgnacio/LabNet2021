using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Consigna1
{
    public class Operaciones
    {
        private static decimal dividendo = 30.2M;
        public static bool Dividir(decimal valor)
        {
            try
            {
                decimal resultado = dividendo / valor;
                Console.WriteLine($"{dividendo}/{valor} = {resultado.ToString("F3")}");
                return true;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
                return false;
            }
           
            finally
            {
                Console.WriteLine("\nLa operacion termino");
            }
        }
    }
}

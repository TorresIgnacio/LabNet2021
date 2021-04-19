using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_Consigna2
{
    public class Operaciones
    {
        public static decimal Dividir()
        {
            decimal divisor, dividendo, resultado;

            try
            {
                Console.WriteLine("Ingrese dividendo:");
                dividendo = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Ingrese divisor:");
                divisor = Convert.ToDecimal(Console.ReadLine());
                resultado = dividendo / divisor;
                Console.WriteLine($"{dividendo}/{divisor} = {resultado.ToString("F3")}");
                return resultado;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!\n");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                Console.WriteLine("\nOperacion Finalizada!");
            }

        }
    }
}

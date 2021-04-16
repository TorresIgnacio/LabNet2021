using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var numeroTransportes = 10;
            
            //En caso de que el numero de transportes dado sea impar se lo convierte a par
            if (numeroTransportes % 2 != 0)
                numeroTransportes++;

            Avion[] flota = new Avion[numeroTransportes/2];
            Automovil[] autos = new Automovil[numeroTransportes/2];
            Transporte[] transportes = new Transporte[numeroTransportes];
            
            for (int i = 0; i < (flota.Length - 1); i++)
            {
                flota[i] = new Avion();
                transportes[i] = flota[i];
            }

            //Se intenta crear avion con mas pasajeros que capacidad maxima
            flota[flota.Length - 1] = new Avion(323, 500);
            transportes[flota.Length - 1] = flota[flota.Length - 1];
            
            for (int i = flota.Length; i < (flota.Length + autos.Length); i++)
            {
                autos[i - flota.Length] = new Automovil();
                transportes[i] = autos[i - flota.Length];
            }
            

            foreach (var item in transportes.Select((value, i) => new { i, value }))
            {
                Console.WriteLine($"Transporte {(item.i + 1).ToString("D2")} es un {item.value.GetType().Name.PadRight(9, '-')}," +
                $" tiene capacidad maxima de {item.value.GetCapacidadMaxima().ToString().PadLeft(3)} pasajeros " +
                $"y transporta {item.value.GetCantidadPasajeros().ToString().PadLeft(3)} pasajeros");
            }

            Console.WriteLine();

            //Prueba de polimorfismo
            Console.Write("Prueba de polimorfismo:\n");
            Console.WriteLine(transportes[2].Avanzar());
            Console.WriteLine(transportes[8].Avanzar());
            Console.WriteLine(transportes[8].Avanzar());
            Console.WriteLine(transportes[8].Avanzar());
            Console.WriteLine(transportes[8].Avanzar());
            Console.WriteLine(transportes[8].Detenerse());
            Console.WriteLine();

            //Prueba de interfaces
            Console.Write("Prueba de interfaces:\n");
            Console.WriteLine(flota[0].Avanzar());
            Console.WriteLine(flota[0].Avanzar());
            Console.WriteLine(flota[0].Despegar());
            Console.WriteLine(flota[0].Avanzar());
            Console.WriteLine(flota[0].Detenerse());
            Console.WriteLine();


            Console.WriteLine("Hay {0} transportes en total", Transporte.GetCantidadTransportes());
            Console.ReadLine();
        }

    }
    }

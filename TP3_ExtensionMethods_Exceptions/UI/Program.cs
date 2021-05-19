using LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var displayMethods = new DisplayMethods();
            string selector = "";
            Console.WriteLine("Bienvenidos al TP3 sobre exceptions y extension methods!");
            while (selector != "s")
            {
                Console.WriteLine("Elija que consigna quiere ver:");
                Console.WriteLine("1 - Consigna 1\n2 - Consigna 2\n3 - Consigna 3 y 4\nS - Salir");
                switch(selector = Console.ReadLine().ToLower())
                {
                    case "1":
                        displayMethods.ConsignaUno();
                        break;
                    case "2":
                        displayMethods.ConsignaDos();
                        break;
                    case "3":
                        displayMethods.ConsignaTresYCuatro();
                        break;
                    case "s":
                        Console.WriteLine("Adios");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
            }
        }

        
    }
}

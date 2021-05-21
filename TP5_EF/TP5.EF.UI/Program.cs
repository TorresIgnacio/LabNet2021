using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.EF.Entities;
using TP5.EF.LOGIC;

namespace TP5.EF.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMethods displayMethods = new DisplayMethods();
            string selector = "";

            Console.WriteLine("Bienvenido al TP5 sobre entity framework!");
            while (selector != "s")
            {
                Console.WriteLine("\nElija la accion que desea realizar:");
                Console.WriteLine("1 - Ver Clientes\n2 - Añadir Cliente\n3 - Modificar Cliente\n4 - Eliminar Cliente\n" +
                    "5 - Ver pedidos de un cliente\nS - Salir");
                switch (selector = Console.ReadLine().ToLower())
                {
                    case "1":
                        displayMethods.PrintCustomers();
                        break;
                    case "2":
                        displayMethods.AddCustomer();
                        break;
                    case "3":
                        displayMethods.ModifyCustomer();
                        break;
                    case "4":
                        displayMethods.DeleteCustomer();
                        break;
                    case "5":
                        displayMethods.GetCustomerOrders();
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

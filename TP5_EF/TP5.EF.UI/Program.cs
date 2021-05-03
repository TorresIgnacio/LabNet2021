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
            CustomersLogic customersLogic = new CustomersLogic();
            OrdersLogic ordersLogic = new OrdersLogic();
            DisplayMethods displayMethods = new DisplayMethods();


            #region Alta, Baja, Modificacion
            try
            {
                customersLogic.Delete("CACTO");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("La ID no existe\n");
            }

            customersLogic.Add(new Customers
            {
                ContactName = "Pepito",
                CustomerID = "CACTO",
                CompanyName = "Compania Falsa",
                Country = "Argentina"
            });

            Console.WriteLine("Despues del Add:");
            var cacto = customersLogic.GetCustomer("CACTO");
            Console.WriteLine("ID: {0}\nCliente: {1}\nCompania: {2}\nPais: {3}\n\n",
                cacto[0].CustomerID,
                cacto[0].ContactName,
                cacto[0].CompanyName,
                cacto[0].Country);

            customersLogic.UpdateLazy(new Customers
            {
                CustomerID = "CACTO",
                CompanyName = "Compania Infalsa",
                Country = "Canada"
            });

            Console.WriteLine("Despues del Update:");

            cacto = customersLogic.GetCustomer("CACTO");
            Console.WriteLine("ID: {0}\nCliente: {1}\nCompania: {2}\nPais: {3}\n\n",
                cacto[0].CustomerID,
                cacto[0].ContactName,
                cacto[0].CompanyName,
                cacto[0].Country);

            #endregion

            Console.WriteLine($"Pedidos de CACTO:");
            foreach (var order in ordersLogic.GetCustomerOrders("CACTU"))
            {
                Console.WriteLine($"Fecha de Pedido: {order.OrderDate}\tRequerido para:{order.RequiredDate}\t");
            }


            var customersBasicInfo = customersLogic.GetBasicInfo();
            var paddings = displayMethods.GetPaddings(customersBasicInfo);

            int i = 0;
            foreach (var customer in customersBasicInfo)
            {
                if (i == 0)
                {
                    Console.WriteLine("\n\n|{0}|{1}|{2}|{3}|",
                        "ID".PadRight(5),
                        "Cliente".PadRight(paddings[0]),
                        "Compania".PadRight(paddings[1]),
                        "Pais".PadRight(paddings[2])
                        );
                    Console.WriteLine("{0}",
                        "-".PadRight(10 + paddings[0] + paddings[1] + paddings[2], '-'));
                }
                Console.WriteLine("|{0}|{1}|{2}|{3}|",
                    customer.customerID.PadRight(5),
                    customer.contactName.PadRight(paddings[0]),
                    customer.companyName.PadRight(paddings[1]),
                    customer.country.PadRight(paddings[2])
                    );
                i++;
            }

            


            Console.Read();




        }
    }
}

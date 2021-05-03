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
            int i = 0;
            CustomersLogic customersLogic = new CustomersLogic();
            OrdersLogic ordersLogic = new OrdersLogic();


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

            Console.WriteLine($"Pedidos de CACTO:");
            foreach (var order in ordersLogic.GetCustomerOrders("CACTU"))
            {
                Console.WriteLine($"Fecha de Pedido: {order.OrderDate}\tRequerido para:{order.RequiredDate}\t");
            }


            //El select * es feo pero que linda me salio la tabla
            #region select * feo
            var query1 = customersLogic.GetAll();
            int padding = customersLogic.CalcPad(query1);

            foreach (var customers in query1)
            {
                if (i == 0)
                    Console.WriteLine("\n\n{0}{1}{2,22}{3,28}",
                    "Cliente".PadLeft(7 + padding / 2),
                    "ID".PadLeft(3 + padding / 2),
                    "Compania",
                    "Pais"
                    );

                Console.WriteLine("|{0}|{1}|{2}|{3,-38}|{4,12}|",
                (i + 1).ToString("D2"),
                customers.ContactName?.PadRight(padding) ?? " ".PadRight(padding),
                customers.CustomerID,
                customers.CompanyName?.PadRight(35) ?? " ".PadRight(35),
                customers.Country ?? " "
                );
                i++;

            }

            Console.Read();
            #endregion
#endregion




        }
    }
}

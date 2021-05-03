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

            #endregion

            Console.WriteLine($"Pedidos de CACTO:");
            foreach (var order in ordersLogic.GetCustomerOrders("CACTU"))
            {
                Console.WriteLine($"Fecha de Pedido: {order.OrderDate}\tRequerido para:{order.RequiredDate}\t");
            }


            /*Nota: Para evitar usar el select * recurri a hacer un metodo por cada columna que necesitaba, no encontre forma de realizar
             * un select de multiples columnas (pero no de todas) sin el uso de la condicion where
             BUG: el Max() de companyName no retorna la string de mayor longitud*/

            var customerID  = customersLogic.GetCustomersIDs();
            var contactName = customersLogic.GetContactsNames();
            var companyName = customersLogic.GetCompaniesNames();
            var country     = customersLogic.GetCountries();

            for (int j = 0; j < customerID.Count; j++)
            {
                
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|",
                (j + 1).ToString("D2"),
                contactName[j].PadRight(contactName.Max().Length),
                customerID[j].PadRight(5),
                companyName[j].PadRight(38),
                country[j].PadRight(13)
                );
            }

           
            Console.Read();




        }
    }
}

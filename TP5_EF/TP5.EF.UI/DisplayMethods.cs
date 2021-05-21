using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.EF.Entities;
using TP5.EF.LOGIC;

namespace TP5.EF.UI
{
    class DisplayMethods
    {
        CustomersLogic customersLogic = new CustomersLogic();
        OrdersLogic ordersLogic = new OrdersLogic();
        public void AddCustomer()
        {
            Console.Clear();
            Console.WriteLine("Instrucciones:\n");
            var usedIDs = customersLogic.GetCustomersIDs();
            var customer = new Customers();

            try
            {
                Console.WriteLine("Ingrese nombre de contacto:");
                customer.ContactName = Console.ReadLine();
                Console.WriteLine("Ingrese nombre de compania (Requerido):");
                customer.CompanyName = Console.ReadLine();
                Console.WriteLine("Ingrese pais:");
                customer.Country = Console.ReadLine();
                customer.CustomerID = GenerateID(customer.CompanyName, usedIDs);
                customersLogic.Add(customer);
                Console.WriteLine($"Operacion exitosa!\nLa ID del nuevo cliente es: {customer.CustomerID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error: {ex.Message}");
            }
        }

        public void ModifyCustomer()
        {
            string userInput;
            Console.WriteLine("Pista: Si solo se aprieta enter el campo no se modificara\n");
            try
            {
                Console.WriteLine("Ingrese ID de cliente que desea modificar: ");
                var customer = customersLogic.GetCustomer(Console.ReadLine());
                
                if (customer == null)
                {
                    Console.WriteLine("No se encontro ningun cliente con esa ID");
                    return;
                }
                
                Console.WriteLine($"Se encontro!\nID: {customer.CustomerID}|Nombre: {customer.ContactName}" +
                    $"|Compania {customer.CompanyName}|Pais: {customer.Country}");
                Console.WriteLine("Ingrese nuevo nombre de contacto:");
                userInput = Console.ReadLine();
                if (userInput != "")
                    customer.ContactName = userInput;
                Console.WriteLine("Ingrese nuevo nombre de compania:");
                userInput = Console.ReadLine();
                if (userInput != "")
                    customer.CompanyName = userInput; Console.WriteLine("Ingrese nuevo pais:");
                customer.Country = Console.ReadLine() ?? customer.Country;
                userInput = Console.ReadLine();
                if (userInput != "")
                    customer.Country = userInput;

                customersLogic.UpdateLazy(customer);
                Console.WriteLine("Operacion exitosa!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error: {ex.Message}");
            }
        }

        public void DeleteCustomer()
        {
            try
            {
                Console.WriteLine("Ingrese ID de cliente que desea eliminar: ");
                var customer = customersLogic.GetCustomer(Console.ReadLine());

                if (customer == null)
                {
                    Console.WriteLine("No se encontro ningun cliente con esa ID");
                    return;
                }

                Console.WriteLine($"Se encontro!\nID: {customer.CustomerID}|Nombre: {customer.ContactName}" +
                    $"|Compania {customer.CompanyName}|Pais: {customer.Country}");
                Console.WriteLine("Esta seguro de querer eliminarlo? Presione s para eliminar");
                if (Console.ReadKey().Key == ConsoleKey.S)
                {
                    customersLogic.Delete(customer.CustomerID);
                    Console.WriteLine("Operacion exitosa!");
                }
            }
           
            catch (Exception ex)
            {
                Console.WriteLine($"Hubo un error de tipo: {ex.Message}\nSeguramente intento borrar un cliente con dependencias");
            }
        }

        public void GetCustomerOrders()
        {
            Console.WriteLine("Ingrese ID de cliente: ");
            var customer = customersLogic.GetCustomer(Console.ReadLine());
            if (customer == null)
            {
                Console.WriteLine("No se encontro ningun cliente con esa ID");
                return;
            }
            var orders = ordersLogic.GetCustomerOrders(customer.CustomerID);
            if (orders.Count == 0)
            {
                Console.WriteLine($"Cliente con ID {customer.CustomerID} no tiene pedidos asociados");
                return;
            }
            foreach (var order in ordersLogic.GetCustomerOrders(customer.CustomerID))
            {
                Console.WriteLine($"Fecha de Pedido: {order.OrderDate}\tRequerido para:{order.RequiredDate}\t");
            }
        }

        public void PrintCustomers()
        {
            var customers = customersLogic.GetCustomersBasicInfo();
            int[] paddings = new int[]
            {
                GetLengthOfLongestString(customers.Select(c => c.customerID).ToList()),
                GetLengthOfLongestString(customers.Select(c => c.contactName).ToList()),
                GetLengthOfLongestString(customers.Select(c => c.companyName).ToList()),
                GetLengthOfLongestString(customers.Select(c => c.country).ToList())
            };

            int i = 0;
            foreach (var customer in customers)
            {
                if (i == 0)
                {
                    Console.WriteLine("\n\n|{0}|{1}|{2}|{3}|",
                        "ID".PadRight(paddings[0]),
                        "Cliente".PadRight(paddings[1]),
                        "Compania".PadRight(paddings[2]),
                        "Pais".PadRight(paddings[3])
                        );
                    Console.WriteLine("{0}",
                        "-".PadRight(paddings[0] + paddings[1] + paddings[2] + paddings[3] + 5, '-'));
                }
                Console.WriteLine("|{0}|{1}|{2}|{3}|",
                    customer.customerID.PadRight(paddings[0]),
                    customer.contactName?.PadRight(paddings[1]) ?? " ".PadRight(paddings[1]),
                    customer.companyName.PadRight(paddings[2]),
                    customer.country?.PadRight(paddings[3]) ?? " ".PadRight(paddings[3])
                    );
                i++;
            }
        }

        string GenerateID(string companyName, List<string> customersIDs)
        {
            string id="";
            char[] idCharArray;
            companyName = EliminateSpecialChars(companyName.ToUpper());
            int position = 4;
            if (companyName.Length >= 5)
                id = companyName.Substring(0, 5);
            else
                id = GenerateRandomString();
            while (customersIDs.Contains(id))
            {
                //idCharArray = id.ToCharArray();
                if (id.ElementAt(position) == 'Z')
                {
                    position -= 1;
                    continue;
                }
                id = id.Substring(0, position) + ((char)(Convert.ToInt32(id.ElementAt(position)) + 1)).ToString() + id.Substring(position + 1 , id.Length - position - 1);
                Console.WriteLine(id);
                //idCharArray[position] = (char)(Convert.ToInt32(idCharArray[position]) + 1) ;
                //id = new string(idCharArray);
            }
            return id;
        }

        string GenerateRandomString()
        {
            Random random = new Random();
            string outString = "";
            string inOptions = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i< 5; i++) {
                outString += inOptions.ElementAt(random.Next(0,inOptions.Length));
            }
            return outString;
        }

        string EliminateSpecialChars(string companyName)
        {
            string newString = "";
            for (int i = 0; i < companyName.Length; i++)
            {
                var c = companyName.ElementAt(i);
                if (c >= 'A' && c <= 'Z')
                    newString+=c;
            }
            return newString;
        }

        int GetLengthOfLongestString(List<string> str)
        {
            string longestString = "";
            foreach (var item in str)
            {
                if (item?.Length > longestString.Length)
                    longestString = item;
            }
            return longestString.Length;
        }
        
    }
}

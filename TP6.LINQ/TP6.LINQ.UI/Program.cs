using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP6.LINQ.Entities;
using TP6.LINQ.LOGIC;

namespace TP6.LINQ.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersLogic customersLogic = new CustomersLogic();
            OrdersLogic ordersLogic = new OrdersLogic();
            ProductsLogic productsLogic = new ProductsLogic();
            DisplayQueries displayQueries = new DisplayQueries();

            #region Queries
            //1.Query para devolver objeto customer
            string ID = "CACTU";
            var query1 = customersLogic.GetCustomer(ID);
            Console.WriteLine("\n\nQuery1: devolver objeto customer");
            try
            {
                displayQueries.printCustomers(new List<Customers> { query1 });
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Customer ID no existe");
            }
            //2.Query para devolver todos los productos sin stock
            var query2 = productsLogic.GetProductsWithXStock(0);
            Console.WriteLine("\n\nQuery2: devolver todos los productos sin stock");
            displayQueries.printProducts(query2);

            //3.Query para devolver todos los productos que tienen stock y que cuestan más de 3 por
            //unidad
            var query3 = productsLogic.GetProductsWithStockAndOverPrice(3);
            Console.WriteLine("\n\nQuery3: devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
            displayQueries.printProducts(query3);

            //4.Query para devolver todos los customers de Washington
            var query4 = customersLogic.GetCustomersFromRegion("WA");
            Console.WriteLine("\n\nQuery4: devolver todos los customers de Washington");
            displayQueries.printCustomers(query4);

            //5.Query para devolver el primer elemento o nulo de una lista de productos donde el ID de
            //producto sea igual a 789
            var query5 = productsLogic.GetProduct(789);
            Console.WriteLine("\n\nQuery 5: devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            displayQueries.printProducts(new List<Products> { query5 });                
            
            //6.Query para devolver los nombre de los Customers.Mostrarlos en Mayuscula y en
            //Minuscula.
            var query6 = customersLogic.GetContactsNames();
            Console.WriteLine("\n\nQuery 6: devolver los nombre de los Customers.Mostrarlos en Mayuscula y en Minuscula.\n");
            foreach (var customer in query6)
            {
                Console.WriteLine("|{0}|{1}|",
                    customer.ToUpper().PadRight(query6.Max().Length),
                    customer.ToLower().PadRight(query6.Max().Length)
                    );
            }

            //7.Query para devolver Join entre Customers y Orders donde los customers sean de
            //Washington y la fecha de orden sea mayor a 1 / 1 / 1997
            var query7 = customersLogic.JoinCustomersOrders("WA", new DateTime(1997, 1, 1));
            Console.WriteLine("\n\nQuery 7: devolver Join entre Customers y Orders donde los customers sean de Washington y la fecha de orden sea mayor a 1 / 1 / 1997\n");

            Console.WriteLine("{0,-5}|{1,-23}|{2,-10}|{3}|",
                    "ID",
                    "Nombre",
                    "Fecha",
                    "Region");
            foreach (var item in query7)
            {
                Console.WriteLine("{0,5}|{1,-23}|{2}/{3:00}/{4:00}|{5,6}|",
                    item.customerID,
                    item.contactName,
                    item.orderDate.Year,
                    item.orderDate.Month,
                    item.orderDate.Day,
                    item.region);
            }

            //8.Query para devolver los primeros 3 Customers de Washington

            var query8 = customersLogic.GetTopCustomersFromRegion(3, "WA");
            Console.WriteLine("\n\nQuery 8: Devolver los primeros 3 Customers de Washington");
            displayQueries.printCustomers(query8);


            //9.Query para devolver lista de productos ordenados por nombre
            
            var query9 = productsLogic.GetProductsOrderedByName();
            Console.WriteLine("\n\nQuery 9: devolver lista de productos ordenados por nombre");
            displayQueries.printProducts(query9);

            //10.Query para devolver lista de productos ordenados por unit in stock de mayor a menor.

            var query10 = productsLogic.GetProductsOrderedByStock();
            Console.WriteLine("\n\nQuery 10: devolver lista de productos ordenados por unit in stock de mayor a menor.");
            displayQueries.printProducts(query10);

            //11.Query para devolver las distintas categorías asociadas a los productos

            var query11 = productsLogic.JoinProductsCategories();
            Console.WriteLine("\n\nQuery 11: devolver las distintas categorías asociadas a los productos\n");
            foreach (var item in query11)
            {
                Console.WriteLine("{0,5}|{1,-40}|{2,-20}|",
                         item.productID,
                         item.productName,
                         item.categoryName
                         );

            }

            //12.Query para devolver el primer elemento de una lista de productos

            var query12 = productsLogic.GetTopProducts(1);
            Console.WriteLine("\n\nQuery 12: devolver el primer elemento de una lista de productos");
            displayQueries.printProducts(query12);

            //13.Query para devolver los customer con la cantidad de ordenes asociadas

            var query13 = customersLogic.GetCustomersOrders();
            Console.WriteLine("\n\nQuery 13: devolver los customer con la cantidad de ordenes asociadas\n");
            foreach (var item in query13)
            {
                Console.WriteLine($"|{item.contactName.PadRight(30)}|{item.cantOrders.ToString().PadLeft(4)}|");
            }
            


            #endregion
            Console.Read();


        }
    }
}

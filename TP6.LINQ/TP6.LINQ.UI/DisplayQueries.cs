using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP6.LINQ.Entities;

namespace TP6.LINQ.UI
{
    class DisplayQueries
    {
        public void printProducts(List<Products> query)
        {
            int i = 0;

            var paddings = GetProductPaddings(query);

            
            
            foreach (var products in query)
            {
                if (i == 0)
                {
                    Console.WriteLine("\n\n|{0}|{1}|{2}|  {3}|",
                        "ID".PadRight(3),
                        "Producto".PadRight(paddings[0]),
                        "Stock".PadRight(6),
                        "Precio".PadRight(6)
                        );

                }
                Console.WriteLine("|{0}|{1}|{2}|  {3:000.00}|",
                    products.ProductID.ToString().PadRight(3),
                    products.ProductName.PadRight(paddings[0]),
                    products.UnitsInStock.ToString().PadLeft(6),
                    products.UnitPrice
                    );
                i++;
            }
        }

        public List<int> GetProductPaddings(List<Products> list)
        {
            string longestName;
            longestName = list.Aggregate("", (max, cur) => max.Length > cur.ProductName.ToString().Length ? max : cur.ProductName.ToString());
            var paddings = new List<int> { longestName.Length};
            return paddings;
        }

        public void printCustomers(List<Customers> query)
        {
            var paddings = GetCustomersPaddings(query);

            int i = 0;
            foreach (var customer in query)
            {
                if (i == 0)
                {
                    Console.WriteLine("\n\n|{0}|{1}|{2}|{3}|{4}|",
                        "ID".PadRight(5),
                        "Cliente".PadRight(paddings[0]),
                        "Compania".PadRight(paddings[1]),
                        "Pais".PadRight(paddings[2]),
                        "Region".PadRight(5)
                        );
                    Console.WriteLine("{0}",
                        "-".PadRight(10 + paddings[0] + paddings[1] + paddings[2] + 5, '-'));
                }
                Console.WriteLine("|{0}|{1}|{2}|{3}|{4}|",
                    customer.CustomerID.PadRight(5),
                    customer.ContactName.PadRight(paddings[0]),
                    customer.CompanyName.PadRight(paddings[1]),
                    customer.Country.PadRight(paddings[2]),
                    customer.Region?.PadRight(5)??"NULL"
                    );
                i++;
            }
        }
        public List<int> GetCustomersPaddings(List<Customers> list)
        {
            string longestContact, longestCompany, longestCountry;

            longestContact = list.Aggregate("", (max, cur) => max.Length > cur.ContactName.ToString().Length ? max : cur.ContactName.ToString());
            longestCompany = list.Aggregate("", (max, cur) => max.Length > cur.CompanyName.ToString().Length ? max : cur.CompanyName.ToString());
            longestCountry = list.Aggregate("", (max, cur) => max.Length > cur.Country.ToString().Length ? max : cur.Country.ToString());
           
            var paddings = new List<int> { longestContact.Length, longestCompany.Length, longestCountry.Length};
            return paddings;
        }
    }
}

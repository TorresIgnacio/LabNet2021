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
            var customersLogic = new CustomersLogic();

            var queryAll = customersLogic.GetAll();
            var querySome = customersLogic.GetCustomersBasicInfo();

            Console.Read();
        }
    }
}

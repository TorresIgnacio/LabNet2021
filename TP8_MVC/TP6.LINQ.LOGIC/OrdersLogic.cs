using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP6.LINQ.Data;
using TP6.LINQ.Entities;

namespace TP6.LINQ.LOGIC
{
    public class OrdersLogic : CommonLogic, IABMLogic<Orders, int>
    {
        public List<Orders> GetCustomerOrders(string customerID)
        {
            var customerOrders = (from order in context.Orders
                             where order.CustomerID == customerID
                             select order).ToList();
            return customerOrders;
        }
        
        public bool Add(Orders newRow)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAndBlank(Orders row)
        {
            throw new NotImplementedException();
        }

        public void UpdateLazy(Orders row)
        {
            throw new NotImplementedException();
        }
        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

    }
}

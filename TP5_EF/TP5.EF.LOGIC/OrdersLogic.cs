﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.EF.Data;
using TP5.EF.Entities;

namespace TP5.EF.LOGIC
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
        
        
        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

        public bool Add(Orders newRow)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLazy(Orders row)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAndBlank(Orders row)
        {
            throw new NotImplementedException();
        }
    }
}

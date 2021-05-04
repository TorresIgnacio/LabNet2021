using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP6.LINQ.Data;
using TP6.LINQ.Entities;

namespace TP6.LINQ.LOGIC
{
    public class CustomersLogic : CommonLogic, IABMLogic<Customers, string>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }


        public Customers GetCustomer(string id)
        {   
            var customer = context.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
            return customer;
        }

        public List<Customers> GetCustomersFromRegion(string region)
        {
            var query4 = context.Customers.Where(c => c.Region == region).ToList();
            return query4;
        }

        public List<JoinedCustomersOrders> JoinCustomersOrders(string region, DateTime date)
        {
            var query7 = (from customer in context.Customers
                         join order in context.Orders
                         on customer.CustomerID equals order.CustomerID
                         where customer.Region == region && order.OrderDate > date
                         select new JoinedCustomersOrders
                         {
                             customerID     = customer.CustomerID,
                             contactName    = customer.ContactName,
                             orderDate      = order.OrderDate??DateTime.MinValue,
                             region         = customer.Region

                         }).ToList();
            return query7;
        }

        public List<Customers> GetTopCustomersFromRegion(int top, string region)
        {
            var query8 = (from customer in context.Customers
                          where customer.Region == region
                          select customer
                          ).Take(top).ToList();
            return query8;
        }

        public List<CustomersOrdersCount> GetCustomersOrders()
        {
            var query13 = (from c in context.Customers
                           join o in context.Orders
                           on c.CustomerID equals o.CustomerID
                           group o by c.ContactName into g
                           select new CustomersOrdersCount{ contactName = g.Key, cantOrders = g.Count() 
                           }).ToList();
            return query13;
        }
        public List<string> GetCustomersIDs()
        {
            var customersIDs = context.Customers.Select(c => c.CustomerID).ToList();
            return customersIDs;
        }

        public List<string> GetContactsNames()
        {
            var contactsNames = context.Customers.Select(c => c.ContactName).ToList();
            return contactsNames;
        }

        public List<string> GetCompaniesNames()
        {
            var companiesNames = context.Customers.Select(c => c.CompanyName).ToList();
            return companiesNames;
        }

        public List<string> GetCountries()
        {
            var countries = context.Customers.Select(c => c.Country).ToList();
            return countries;
        }

        public void Add(Customers newCustomer)
        {
            //Verifica que la id del nuevo cliente que se quiere agregar no exista
            if (!context.Customers.Any(c => c.CustomerID == newCustomer.CustomerID))
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }

        }

        public void Delete(string id)
        {
            var customerAEliminar = context.Customers.Find(id);

            context.Customers.Remove(customerAEliminar);

            context.SaveChanges();
        }


        //UpdateLazy updatea los campos provistos dejando tal cual estaban los que no han sido especificados
        public void UpdateLazy(Customers customer)
        {
            var customerUpdate = context.Customers.Find(customer.CustomerID);

            customerUpdate.Address              = customer.Address              ?? customerUpdate.Address;
            customerUpdate.City                 = customer.City                 ?? customerUpdate.City;
            customerUpdate.CompanyName          = customer.CompanyName          ?? customerUpdate.CompanyName;
            customerUpdate.ContactName          = customer.ContactName          ?? customerUpdate.ContactName;
            customerUpdate.ContactTitle         = customer.ContactTitle         ?? customerUpdate.ContactTitle;
            customerUpdate.Country              = customer.Country              ?? customerUpdate.CompanyName;
            customerUpdate.CustomerDemographics = customer.CustomerDemographics ?? customerUpdate.CustomerDemographics;
            context.SaveChanges();
        }

        //UpdateAndBlank updatea los campos provistos y blanquea los que no han sido especificados
        public void UpdateAndBlank(Customers customer)
        {
            var customerUpdate = context.Customers.Find(customer.CustomerID);

            customerUpdate.Address              = customer.Address;
            customerUpdate.City                 = customer.City;
            customerUpdate.CompanyName          = customer.CompanyName ?? customerUpdate.CompanyName;   //No Nulleable
            customerUpdate.ContactName          = customer.ContactName;
            customerUpdate.ContactTitle         = customer.ContactTitle;
            customerUpdate.Country              = customer.Country;
            customerUpdate.CustomerDemographics = customer.CustomerDemographics;

            context.SaveChanges();
        }

        public int CalcPad(List<Customers> customers)
        {
            var maxLength = customers.Max(c => c.ContactName);
            return maxLength.Length;
        }

    }
}

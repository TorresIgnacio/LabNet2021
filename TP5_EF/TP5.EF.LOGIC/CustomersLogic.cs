using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP5.EF.Data;
using TP5.EF.Entities;

namespace TP5.EF.LOGIC
{
    public class CustomersLogic : CommonLogic, IABMLogic<Customers, string>
    {
        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }


        public List<Customers> GetCustomer(string customerID)
        {
            var customer = (from cust in context.Customers
                                  where cust.CustomerID == customerID
                                  select cust).ToList();
            return customer;
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

        public List<CustomersBasicInfo> GetBasicInfo()
        {
            var customers = context.Customers.Select(cust => new CustomersBasicInfo
            {
                customerID  = cust.CustomerID,
                contactName = cust.ContactName,
                companyName = cust.CompanyName,
                country     = cust.Country
            }).ToList();
            
            return customers;
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
            customerUpdate.Country              = customer.Country              ?? customerUpdate.Country;
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

            context.SaveChanges();
        }

        public int CalcPad(List<Customers> customers)
        {
            var maxLength = customers.Max(c => c.ContactName);
            return maxLength.Length;
        }

    }
}

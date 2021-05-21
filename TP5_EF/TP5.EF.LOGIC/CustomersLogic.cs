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

        public List<CustomersBasicInfo> GetCustomersBasicInfo()
        {
            var customers = context.Customers.Select(c => new CustomersBasicInfo
            {
                customerID = c.CustomerID,
                contactName= c.ContactName,
                companyName=c.CompanyName,
                country = c.Country
            }).ToList();
            return customers;
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

        public List<Customers> GetTopCustomersFromRegion(int top, string region)
        {
            var query8 = (from customer in context.Customers
                          where customer.Region == region
                          select customer
                          ).Take(top).ToList();
            return query8;
        }
        public List<string> GetCustomersIDs()
        {
            var customersIDs = context.Customers.Select(c => c.CustomerID).ToList();
            return customersIDs;
        }

        public bool Add(Customers newCustomer)
        {
            try
            {
                //Verifica que la id del nuevo cliente que se quiere agregar no exista
                ValidateCustomer(newCustomer);

                if (!context.Customers.Any(c => c.CustomerID == newCustomer.CustomerID))
                {
                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }   
        }

        public void Delete(string id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentException("La ID no puede estar vacía");
                if (id.Length != 5)
                    throw new ArgumentException("La ID debe tener 5 letras");
                if (!id.All(c => char.IsLetter(c)))
                    throw new ArgumentException("La ID no puede contener números o símbolos");

                var customerAEliminar = context.Customers.Find(id);
                if (customerAEliminar == null)
                    throw new ArgumentNullException("No existe ningún customer con esa ID");
                context.Customers.Remove(customerAEliminar);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //UpdateLazy updatea los campos provistos dejando tal cual estaban los que no han sido especificados
        public bool UpdateLazy(Customers customer)
        {
            try
            {
                var customerUpdate = context.Customers.Find(customer.CustomerID);
                if (customerUpdate == null)
                    return false;
                ValidateCustomer(customer);


                customerUpdate.Address = customer.Address ?? customerUpdate.Address;
                customerUpdate.City = customer.City ?? customerUpdate.City;
                customerUpdate.CompanyName = customer.CompanyName ?? customerUpdate.CompanyName;
                customerUpdate.ContactName = customer.ContactName ?? customerUpdate.ContactName;
                customerUpdate.ContactTitle = customer.ContactTitle ?? customerUpdate.ContactTitle;
                customerUpdate.Country = customer.Country ?? customerUpdate.Country;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //UpdateAndBlank updatea los campos provistos y blanquea los que no han sido especificados
        public bool UpdateAndBlank(Customers customer) ///Devuelve un null si no encuentra nada
        {
            try
            {
                var customerUpdate = context.Customers.Find(customer.CustomerID);
                if (customerUpdate == null)
                    return false;
                ValidateCustomer(customer);

                customerUpdate.Address = customer.Address;
                customerUpdate.City = customer.City;
                customerUpdate.CompanyName = customer.CompanyName;
                customerUpdate.ContactName = customer.ContactName;
                customerUpdate.ContactTitle = customer.ContactTitle;
                customerUpdate.Country = customer.Country;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CalcPad(List<Customers> customers)
        {
            var maxLength = customers.Max(c => c.ContactName);
            return maxLength.Length;
        }

        public void ValidateCustomer(Customers customer)
        {
            if (customer.CustomerID == null)
                throw new ArgumentException("La ID no puede estar vacía");
            if (customer.CustomerID.Length != 5)
                throw new ArgumentException("La ID debe tener 5 letras");
            if (!customer.CustomerID.All(c => char.IsLetter(c)))
                throw new ArgumentException("La ID no puede contener números o símbolos");
            if (customer.CompanyName == null)
                throw new ArgumentException("El nombre de la compañía no puede estar vacío");
            if (customer.CompanyName.Length > 40)
                throw new ArgumentException("CompanyName no puede tener más de 40 caracteres");
            if (customer.ContactName != null)
            {
                if (!customer.ContactName.All(c => char.IsLetter(c) || char.IsSeparator(c)))
                    throw new ArgumentException("ContactName no puede contener números o símbolos");
                if (customer.ContactName.Length > 30)
                    throw new ArgumentException("ContactName no puede tener más de 30 caracteres");
            }
            return;
        }

    }
}

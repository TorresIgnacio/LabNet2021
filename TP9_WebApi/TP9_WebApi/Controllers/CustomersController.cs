using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TP6.LINQ.LOGIC;
using TP9_WebApi.Models;

namespace TP9_WebApi.Controllers
{
    public class CustomersController : ApiController
    {
        CustomersLogic customerLogic = new CustomersLogic();
        
        // GET api/customers
        [ResponseType(typeof(List<CustomerView>))]
        public IHttpActionResult Get()
        {
            var customers = customerLogic.GetAll();
            var customerView = customers.Select(c => new CustomerView
            {
                ID = c.CustomerID,
                contactName = c.ContactName,
                companyName = c.CompanyName
            }).ToList();
            return Ok(customerView);
        }

        // GET api/customers/{id}
        [ResponseType(typeof(CustomerView))]
        public IHttpActionResult Get(string ID)
        {
            var customers = customerLogic.GetCustomer(ID);
            if (customers == null)
                return NotFound();
            var customerView = new CustomerView
            {
                ID = customers.CustomerID,
                contactName = customers.ContactName,
                companyName = customers.CompanyName
            };
            return Ok(customerView);
        }

        [ResponseType(typeof(CustomerView))]
        public IHttpActionResult Post(CustomerView customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newCustomer = new TP6.LINQ.Entities.Customers
            {
                CustomerID = customer.ID,
                ContactName = customer.contactName,
                CompanyName = customer.companyName
            };

            try
            {
                customerLogic.Add(newCustomer);
                return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ResponseType(typeof(CustomerView))]
        public IHttpActionResult Delete(string ID)
        {
            try
            {
                var customer = customerLogic.GetCustomer(ID);
                if (customer == null)
                    return NotFound();
                customerLogic.Delete(ID);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        [ResponseType(typeof(CustomerView))]
        public IHttpActionResult Patch(string ID, CustomerView customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ID != customer.ID)
            {
                return BadRequest();
            }

            var updateCustomer = new TP6.LINQ.Entities.Customers
            {
                CustomerID = customer.ID,
                ContactName = customer.contactName,
                CompanyName = customer.companyName
            };

            try
            {
                if (customerLogic.UpdateLazy(updateCustomer))
                    return Ok(updateCustomer);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ResponseType(typeof(CustomerView))]
        public IHttpActionResult Put(string ID, CustomerView customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ID != customer.ID)
            {
                return BadRequest();
            }

            var replaceCustomer = new TP6.LINQ.Entities.Customers
            {
                CustomerID = customer.ID,
                ContactName = customer.contactName,
                CompanyName = customer.companyName
            };

            try
            {
                if (customerLogic.UpdateAndBlank(replaceCustomer))
                    return Ok(replaceCustomer);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }

}

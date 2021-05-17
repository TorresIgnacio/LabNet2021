using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP6.LINQ.LOGIC;
using TP8_MVC.Models;

namespace TP8_MVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomersLogic customerLogic = new CustomersLogic();
        // GET: Customer
        public ActionResult Index()
        {
            
            List<TP6.LINQ.Entities.Customers> customer = customerLogic.GetAll();
            List<CustomerView> customerViews = customer.Select(c => new CustomerView
            {
                ID = c.CustomerID,
                contactName = c.ContactName,
                companyName = c.CompanyName
            }).ToList();
            return View(customerViews);
        }

        public ActionResult Delete(string ID)
        {
            try
            {
                customerLogic.Delete(ID);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("Index", "Error");
            }
        }
        public ActionResult AddMod(string ID)
        {
            if (ID == null)
                return View();
            TP6.LINQ.Entities.Customers customer = customerLogic.GetCustomer(ID);
            CustomerView customerView = new CustomerView()
            {
                ID = customer.CustomerID,
                contactName = customer.ContactName,
                companyName = customer.CompanyName
            };
            return View(customerView);
        }


        [HttpPost]
        public ActionResult AddMod(CustomerView customerView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customerEntity = new TP6.LINQ.Entities.Customers
                    {
                        CustomerID = customerView.ID,
                        ContactName = customerView.contactName,
                        CompanyName = customerView.companyName
                    };
                    if (!customerLogic.Add(customerEntity))
                        customerLogic.UpdateLazy(customerEntity);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = ex.Message;
                    return RedirectToAction("Index", "Error");
                }

            }
            return View();
        }


    }
}
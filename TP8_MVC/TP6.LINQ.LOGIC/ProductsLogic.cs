using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP6.LINQ.Entities;

namespace TP6.LINQ.LOGIC
{
    public class ProductsLogic : CommonLogic, IABMLogic<Products, int>
    {

        public List<Products> GetProductsWithXStock(int stock)
        {
            var query2 = context.Products.Where(p => p.UnitsInStock == stock).ToList();
            return query2;
        }

        public List<Products> GetProductsWithStockAndOverPrice(int price)
        {
            var query3 = context.Products.Where(p => p.UnitsInStock != 0 && p.UnitPrice > price).ToList();
            return query3;
        }

        public Products GetProduct(int id)
        {
            var query5 = context.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return query5;
        }

        public List<Products> GetProductsOrderedByName()
        {
            var query9 = (from products in context.Products
                         orderby products.ProductName
                         select products
                         ).ToList();

            return query9;
        }

        public List<Products> GetProductsOrderedByStock()
        {
            var query10 = (from products in context.Products
                          orderby products.UnitsInStock descending
                          select products
                          ).ToList();
            return query10;
        }

        public List<Products> GetTopProducts(int top)
        {
            var query12 = context.Products.Take(top).ToList();
            return query12;
        }

        public List<JoinedProductsCategories> JoinProductsCategories()
        {
            var query7 = (from products in context.Products
                          join categories in context.Categories
                          on products.CategoryID equals categories.CategoryID
                          select new JoinedProductsCategories
                          {
                              productID = products.ProductID,
                              productName = products.ProductName,
                              categoryName  = categories.CategoryName,
                              categoryDescription = categories.Description

                          }).ToList();
            return query7;
        }
        public bool Add(Products newRow)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateAndBlank(Products row)
        {
            throw new NotImplementedException();
        }

        public void UpdateLazy(Products row)
        {
            throw new NotImplementedException();
        }
    }
}

using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace AssistPurchase.Repositories.ProductDatabase
{
    public class ProductDatabaseHandler : IProductDatabaseHandler
    {
        private readonly DatabaseContext _db;

        public ProductDatabaseHandler(DatabaseContext context)
        {
            this._db = context;
        }
        public IEnumerable<Product> GetAllProductsFromDb()
        {
            //try
            {
                
                return _db.Products.ToList();
            }
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    return null;
            //}
        }

        public HttpStatusCode AddProductToDb(Product product)
        {
            //try
            {
                var dbProduct = _db.Products.FirstOrDefault(b => b.Id == product.Id);
                if (dbProduct != null)
                    return HttpStatusCode.Unauthorized;
                _db.Add(product);
                _db.SaveChanges();
                return HttpStatusCode.OK;
            }
            //catch (Exception e)
            //{
            //    return InternalServerError(e);
            //}
        }

        public Product GetProductByNameFromDb(string name)
        {
            //try
            {
               
                return _db.Products.FirstOrDefault(b => b.Name == name);
            }
            //catch (Exception e) { throw new ApplicationException("Problem with Database", e); }
        }

        public HttpStatusCode UpdateProductInDb(Product product)
        {
            var dbProduct = _db.Products.FirstOrDefault(b => b.Id == product.Id);
            //try
            {
                if (dbProduct == null)
                    return HttpStatusCode.NotFound;
                _db.Remove(dbProduct);
                _db.Add(product);
                _db.SaveChanges();

                return HttpStatusCode.OK;
            }
            //catch (Exception e)
            //{
            //    return InternalServerError(e);
            //}
        }

        public HttpStatusCode RemoveProductFromDb(string id)
        {
            //try
            {
                
                var product = _db.Products.FirstOrDefault(b => b.Id == id);
                if (product == null)
                    return HttpStatusCode.NotFound;
                _db.Remove(product);
                _db.SaveChanges();
                return HttpStatusCode.OK;
            }
            //catch (Exception e)
            //{
            //    return InternalServerError(e);
            //}
        }

        //private static HttpStatusCode InternalServerError(Exception e)
        //{
        //    Trace.TraceInformation(e.Message);
        //    return HttpStatusCode.InternalServerError;
        //}
    }
}

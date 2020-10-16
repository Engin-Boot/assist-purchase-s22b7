using DatabaseContractor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace DatabaseManager
{
    public class ProductDatabaseHandler : IProductDatabaseHandler
    {
        public IEnumerable<Product> GetAllProductsFromDb()
        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();
                return _db.Products.ToList();
            }
            catch (Exception e) { throw new ApplicationException("Problem with Database", e); }
        }

        public HttpStatusCode AddProductToDb(Product product)
        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();

                var Dproduct = _db.Products.Where(b => b.Id == product.Id).FirstOrDefault();
                if (Dproduct != null)
                    return HttpStatusCode.Unauthorized;
                _db.Add(product);
                _db.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        public Product GetProductByNameFromDb(string name)
        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();
                return _db.Products
                 .Where(b => b.Name == name).FirstOrDefault();
            }
            catch (Exception e) { throw new ApplicationException("Problem with Database", e); }
        }

        public HttpStatusCode UpdateProductInDb(Product product)
        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();

                var Dproduct = _db.Products.Where(b => b.Id == product.Id).FirstOrDefault();
                if (Dproduct == null)
                    return HttpStatusCode.NotFound;
                _db.Remove(Dproduct);
                _db.Add(product);
                _db.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        public HttpStatusCode RemoveProductFromDb(string id)
        {
            try
            {
                using AssistPurchaseContext _db = new AssistPurchaseContext();
                var product = _db.Products.Where(b => b.Id == id).FirstOrDefault();
                if (product == null)
                    return HttpStatusCode.NotFound;
                _db.Remove(product);
                _db.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        private static HttpStatusCode InternalServerError(Exception e)
        {
            Trace.TraceInformation(e.Message);
            return HttpStatusCode.InternalServerError;
        }
    }
}

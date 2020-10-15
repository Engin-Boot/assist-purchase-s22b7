using DatabaseContractor;
using DatabaseManager.ProductDatabase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace DatabaseManager
{
    class ProductDatabaseHandler : IProductDatabaseHandler
    {
        public List<Product> GetAllProducts()
        {
            try
            {
                using ProductContext _db = new ProductContext();
                return _db.Products.ToList();
            }
            catch (Exception e) { throw e; }
        }

        public HttpStatusCode AddProductToDb(Product product)
        {
            try
            {
                using ProductContext _db = new ProductContext();
                if (string.IsNullOrEmpty(product.Name))
                    return HttpStatusCode.BadRequest;

                _db.AddAsync(product);
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
                using ProductContext _db = new ProductContext();
                return _db.Products
                 .Where(b => b.Name == name).FirstOrDefault();
            }
            catch (Exception e) { throw e; }
        }


        public Product GetProductByIdFromDb(string id) => GetByID(id);

        private Product GetByID(string id)
        {
            try
            {
                using ProductContext _db = new ProductContext();
                return _db.Products.Find(id);
            }
            catch (Exception e) { throw e; }
        }


        public HttpStatusCode UpdateProductInDb(Product product)
        {
            try
            {
                using ProductContext _db = new ProductContext();

                if (string.IsNullOrEmpty(product.Id))
                    return HttpStatusCode.BadRequest;

                var dbProduct = GetByID(product.Id);
                if (dbProduct == null)
                    return HttpStatusCode.NotFound;

                var properties = Utilities.GetProperties<Product>();
                foreach (var prop in properties)
                {
                    if (Utilities.HasPropertyValue(prop, product))
                        prop.SetValue(dbProduct, prop.GetValue(product, null));
                }

                _db.Remove(_db.Products.Where(b => b.Id == product.Id));
                _db.AddAsync(dbProduct);
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
                using ProductContext _db = new ProductContext();
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

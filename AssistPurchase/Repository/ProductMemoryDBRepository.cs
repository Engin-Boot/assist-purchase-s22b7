using AssistPurchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchase.Repository
{
    public class ProductMemoryDBRepository : IProductDataRepository
    {
        List<Models.ProductDataModel> _db = new List<ProductDataModel>();

        // ITransactionManager _tranx;
        public ProductMemoryDBRepository()
        {

            _db.Add(new ProductDataModel
            {
                ProductName = "display1",
                ProductId = "X001",
            }
            );
            _db.Add(new ProductDataModel
            {
                ProductName = "display2",
                ProductId= "X002",
            }
            );
            _db.Add(new ProductDataModel
            {
                ProductName = "display3",
                ProductId = "X003",
            }
           );
        }
        public void AddNewProduct(ProductDataModel newState)
        {
            _db.Add(newState);
        }

        public IEnumerable<ProductDataModel> GetAllProducts()
        {
            return _db;
        }


        public void Remove(string id)
        {
            for (int i = 0; i < _db.Count; i++)
            {
                if (_db[i].ProductId == id)
                {
                    _db.Remove(_db[i]);
                    return;
                }
            }
        }

        public void UpdateProductInfo(string id, ProductDataModel state)
        {

            for (int i = 0; i < _db.Count; i++)
            {
                if (_db[i].ProductId == id)
                {
                    _db.Insert(i, state);
                    return;
                }
            }
        }
    }
}

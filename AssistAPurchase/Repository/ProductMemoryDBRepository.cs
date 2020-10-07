using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistAPurchase.Utility;
using AssistAPurchase.Models;

namespace AssistAPurchase.Repository
{
    public class ProductMemoryDBRepository:IProductDataRepository
    {
        List<Models.ProductDataModel> _db = new List<ProductDataModel>();

        // ITransactionManager _tranx;
        public ProductMemoryDBRepository()
        {

            _db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue",
                ProductId = "X3"
            }
            );
            _db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue",
                ProductId = "MX40"
            }
            );
            _db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue",
                ProductId = "MX750"
            }
            );
        }
        public void AddNewProduct(ProductDataModel newState, ITransactionManager manager)
        {
            manager.GetTransaction();
            _db.Add(newState);
        }

        public IEnumerable<ProductDataModel> GetAllProducts(ITransactionManager manager)
        {
            return _db;
        }

        public void RemoveProduct(string id, ITransactionManager manager)
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

        public void UpdateProductInfo(string id, ProductDataModel state, ITransactionManager manager)
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


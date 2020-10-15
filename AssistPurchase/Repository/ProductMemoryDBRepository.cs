using AssistPurchase.Models;
using System.Collections.Generic;

namespace AssistPurchase.Repository
{
    public class ProductMemoryDBRepository : IProductDataRepository
    {
        List<Models.ProductDataModel> _db = new List<ProductDataModel>();
        List<Models.SalesPersonDataModel> _salesInfoData = new List<SalesPersonDataModel>();

        public ProductDataModel AddNewProduct(ProductDataModel newState)
        {
            _db.Add(newState);
            return _db[_db.Count - 1];
        }

        public IEnumerable<ProductDataModel> GetAllProducts()
        {
            return _db;
        }

        public ProductDataModel GetProductById(string id)
        {
            //return _db.Where(a =>a.ProductId == id).FirstOrDefault();
            for (int i = 0; i < _db.Count; i++)
            {
                if (_db[i].ProductId == id)
                {
                    return _db[i];
                }
            }
            return null;
        }

        public void Remove(string id)
        {
            for (int i = 0; i < _db.Count; i++)
            {
                if (_db[i].ProductId == id)
                {
                    _db.Remove(_db[i]);
                }
            }
        }

        public bool UpdateProductInfo(string id, ProductDataModel state)
        {
            for (int i = 0; i < _db.Count; i++)
            {
                if (_db[i].ProductId == id)
                {
                    _db.Insert(i, state);
                    return true;

                }
            }
            return false;
        }

        public IEnumerable<SalesPersonDataModel> GetSalesPersonDetails()
        {
            return _salesInfoData;
        }

        public bool UpdateSalesPersonInfo(string uid, SalesPersonDataModel state1)
        {
            for (int i = 0; i < _salesInfoData.Count; i++)
            {
                if (_salesInfoData[i].SalesPersonId == uid)
                {
                    _salesInfoData.Insert(i, state1);
                    return true;

                }
            }
            return false;
        }

    }
}

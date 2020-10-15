using AssistPurchase.Models;
using System.Collections.Generic;

namespace AssistPurchase.Repository
{
    public class UserMemoryDBRepository : IUserDataRepository
    {

        public UserMemoryDBRepository()
        {


            public ProductDataModel AddNewProduct(ProductDataModel newState)
            {
                _db.Add(newState);
                return _db[_db.Count - 1];
            }

            public IEnumerable<ProductDataModel> GetAllProducts()
            {
                return _db;
            }
            public IEnumerable<ProductDataModel> GetProductByWearability(string wearable)
            {
                for (int i = 0; i < _db.Count; i++)
                {
                    if (_db[i].Wearable == wearable)
                    {
                        return _db;
                    }
                }
                return null;
            }
            public IEnumerable<ProductDataModel> GetProductByPrice(string price)
            {
                for (int i = 0; i < _db.Count; i++)
                {
                    if (_db[i].ProductPrice == price)
                    {
                        return _db;
                    }
                }
                return null;
            }

            public ProductDataModel GetProductById(string id)
            {
                for (int i = 0; i < _db.Count; i++)
                {
                    if (_db[i].ProductId == id)
                    {
                        return _db[i];
                    }
                }
                return null;
            }
        }
    }


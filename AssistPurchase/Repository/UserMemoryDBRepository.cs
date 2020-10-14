using System.Collections.Generic;
using AssistPurchase.Models;

namespace AssistPurchase.Repository
{
    public class UserMemoryDBRepository : IUserDataRepository
    {
        List<Models.ProductDataModel> _db = new List<ProductDataModel>();


        // ITransactionManager _tranx;
        public UserMemoryDBRepository()
        {

            _db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue",
                ProductId = "X3",
                ProductPrice = "25000",
                TouchScreen = "Yes",
                DisplaySize = "6",
                DisplayType = "LCD",
                Battery = "Yes",
                BatteryCapacity = "5",
                Portability = "Yes",
                Weight = "1.4",
                Wearable = "No",
            }
            );
            _db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue",
                ProductId = "MX750",
                ProductPrice = "50000",
                TouchScreen = "Yes",
                DisplaySize = "19",
                DisplayType = "LCD",
                Battery = "No",
                BatteryCapacity = "0",
                Portability = "No",
                Weight = "1.8",
                Wearable = "No",
            }
            );
            _db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue",
                ProductId = "MP2",
                ProductPrice = "20000",
                TouchScreen = "No",
                DisplaySize = "3.5",
                DisplayType = "LCD",
                Battery = "Yes",
                BatteryCapacity = "6",
                Portability = "Yes",
                Weight = "1.5",
                Wearable = "Yes",
            }
           );
            _db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue",
                ProductId = "MP5",
                ProductPrice = "35000",
                TouchScreen = "Yes",
                DisplaySize = "6",
                DisplayType = "LCD",
                Battery = "No",
                BatteryCapacity = "0",
                Portability = "No",
                Weight = "3",
                Wearable = "No",
            }
            );
            _db.Add(new ProductDataModel
            {
                ProductName = "IntelliVue",
                ProductId = "MX450",
                ProductPrice = "40000",
                TouchScreen = "Yes",
                DisplaySize = "12",
                DisplayType = "LCD",
                Battery = "No",
                BatteryCapacity = "0",
                Portability = "Yes",
                Weight = "2",
                Wearable = "No",
            }
            );
        }

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


using DatabaseContractor;
using DatabaseManager;
using System.Linq;
using System.Net;
using Xunit;

namespace AssistPurchaseTest.DatabaseManagerTest
{
    public class ProductDatabaseHandlerTest
    {
        readonly IProductDatabaseHandler _productDatabaseHandler;
        public ProductDatabaseHandlerTest()
        {
            _productDatabaseHandler = new ProductDatabaseHandler();
        }

        [Fact]
        public void WhenRequestIsGoodThenAddProductToDb()
        {
            var product1 = new Product
            {
                Id = "ADC100",
                Name = "IntelliVue X3",
                DisplaySize = 5,
                DisplayType = "LCD",
                Weight = 1.3,
                TouchScreen = false
            };

            var res = _productDatabaseHandler.AddProductToDb(product1);
            Assert.True( res == HttpStatusCode.OK);

        }

        [Fact]
        public void WhenProductIsFoundThenUpdateTheProduct()
        {
            var product2 = new Product
            {
                Id = "ADC100",
                Name = "IntelliVue X3",
                DisplaySize = 5,
                DisplayType = "LCD",
                Weight = 1.3,
                TouchScreen = true
            };

            var res = _productDatabaseHandler.UpdateProductInDb(product2);
            Assert.True(res == HttpStatusCode.OK);
        }

        [Fact]
        public void WhenProductIsNotFoundDuringUpdateThenReturnStatusNotFound()
        {
            var product3 = new Product
            {
                Id = "ADC103",
                Name = "IntelliVue X7",
                DisplaySize = 6,
                DisplayType = "LCC",
                Weight = 1.3,
                TouchScreen = true
            };

            var res = _productDatabaseHandler.UpdateProductInDb(product3);
            Assert.True( res == HttpStatusCode.NotFound);
        }

        [Fact]
        public void WhenServerIsGoodThenGetAllProductFromDb()
        {
            var productList = _productDatabaseHandler.GetAllProductsFromDb();
            Assert.True( productList.Any());
        }

        [Fact]
        public void WhenServerIsGoodThenGetProductByNameFromDb()
        {
            var product = _productDatabaseHandler.GetProductByNameFromDb("IntelliVue X3");
            Assert.True(product.Name == "IntelliVue X3");
            
        }

        [Fact]
        public void WhenRequestIsGoodButNotFoundDuringRemoveThenReturnNotFound()
        {
            Assert.True(_productDatabaseHandler.RemoveProductFromDb("XYZ123") == HttpStatusCode.NotFound);
        }

        [Fact]
        public void WhenRequestIsGoodThenRemoveProductToDb()
        {
            Assert.True(_productDatabaseHandler.RemoveProductFromDb("ADC100") == HttpStatusCode.OK);

        }

    }
}
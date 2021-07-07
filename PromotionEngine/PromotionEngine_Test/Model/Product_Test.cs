using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Model;

namespace PromotionEngine_Test.Model
{
    [TestClass]
    public class Product_Test
    {
        /// <summary>
        /// Create a Sku C with price 20
        /// </summary>
        [TestMethod]
        public void Create_Product_C_With_Price_20()
        {
            var product = new Product("C", 20);
            Assert.AreEqual("C", product.Sku);
            Assert.AreEqual(20, product.Unit_price);
        }

        /// <summary>
        /// Create a Sku C with price 20 and change the price to 70
        /// </summary>
        [TestMethod]
        public void Change_Product_C_Price_From_20_To_70()
        {
            var product = new Product("C", 20);
            Assert.AreEqual("C", product.Sku);
            Assert.AreEqual(20, product.Unit_price);
            product.Unit_price = 70;
            Assert.AreEqual(70, product.Unit_price);
        }
    }
}

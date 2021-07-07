using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Model;

namespace PromotionEngine_Test.Model
{
    [TestClass]
    public class Cart_Test
    {
        /// <summary>
        /// Create an empty cart and verify the count is zero
        /// </summary>
        [TestMethod]
        public void Create_Empty_Cart()
        {
            Cart cart = new Cart();
            Assert.AreEqual(0, cart.GetTotalCount());
        }

        /// <summary>
        /// Addidng two product type items and verifying the result
        /// </summary>
        [TestMethod]
        public void Create_Cart_With_Products()
        {
            Cart cart = new Cart();
            cart.Add(new Product("A", 50), 5);
            cart.Add(new Product("B", 20), 10);

            Assert.AreEqual(2, cart.GetTotalCount());
        }
    }
}

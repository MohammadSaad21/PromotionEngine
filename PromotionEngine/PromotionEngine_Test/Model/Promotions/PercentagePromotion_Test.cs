using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Model;
using PromotionEngine.Model.Promotions;

namespace PromotionEngine_Test.Model.Promotions
{
    [TestClass]
    public class PercentagePromotion_Test
    {
        /// <summary>
        /// Add 3 * SkuA to the cart an calculate the discount. Original price is 150. Expected discount is 45 after applying 30%
        /// </summary>
        [TestMethod]
        public void Discount_For_3As_Equal_20()
        {
            var SkuA = new Product("A", 50);
            var promotion = new PercentagePromotion(1, new DateTime(2021, 07, 01), new DateTime(2021, 12, 15), SkuA, 30);
            var cart = new Cart();
            cart.Add(SkuA, 3);

            Assert.AreEqual(45, promotion.CalculateDiscount(cart));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Model;
using PromotionEngine.Model.Promotions;

namespace PromotionEngine_Test.Model.Promotions
{
    [TestClass]
    public class AmountPromotion_Test
    {
        /// <summary>
        /// Add 3 * SkuA to the cart an calculate the discount. Original price is 150. Expected discount is 20
        /// </summary>
        [TestMethod]
        public void Discount_For_3As_Equal_20()
        {
            var SkuA = new Product("A", 50);
            var promotion = new AmountPromotion(1, new DateTime(2021, 07, 01), new DateTime(2021, 12, 15), SkuA, 3, 130);
            var cart = new Cart();
            cart.Add(SkuA, 3);

            Assert.AreEqual(20, promotion.CalculateDiscount(cart));
        }

        /// <summary>
        /// Add 10 * SkuA to the cart an calculate the discount. Original price is 500. Expected discount is 60
        /// </summary>
        [TestMethod]
        public void Discount_For_10As_Equal_60()
        {
            var SkuA = new Product("A", 50);
            var promotion = new AmountPromotion(1, new DateTime(2021, 07, 01), new DateTime(2021, 12, 15), SkuA, 3, 130);
            var cart = new Cart();
            cart.Add(SkuA, 10);

            Assert.AreEqual(60, promotion.CalculateDiscount(cart));
        }
    }
}

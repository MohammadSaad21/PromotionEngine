using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Model;
using PromotionEngine.Model.Promotions;

namespace PromotionEngine_Test.Model.Promotions
{
    [TestClass]
    public class CombinedPromotion_Test
    {
        /// <summary>
        /// Add 1 * SkuC and 1 * SkuD to the cart an calculate the discount. Original price is 35. Expected discount is 5
        /// </summary>
        [TestMethod]
        public void Discount_For_C_And_D_Equal_5()
        {
            var skuC = new Product("C", 20);
            var skuD = new Product("D", 15);

            var discountCombination = new List<Product>();
            discountCombination.Add(skuC);
            discountCombination.Add(skuD);

            var combinedPromotion = new CombinedPromotion(1, new DateTime(2021, 07, 01), new DateTime(2021, 12, 15), discountCombination, 30);

            var cart = new Cart();
            cart.Add(skuC, 1);
            cart.Add(skuD, 1);

            Assert.AreEqual(5, combinedPromotion.CalculateDiscount(cart));
        }
    }
}

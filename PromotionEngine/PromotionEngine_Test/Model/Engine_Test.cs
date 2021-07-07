using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Model;
using PromotionEngine.Model.Promotions;

namespace PromotionEngine_Test.Model
{
    [TestClass]
    public class Engine_Test
    {
        /// <summary>
        /// Test scenario A, B and C
        /// </summary>
        [TestMethod]
        public void TotalPrice_Scenario_A_B_C()
        {
            var SkuA = new Product("A", 50);
            var SkuB = new Product("B", 30);
            var SkuC = new Product("C", 20);
            var SkuD = new Product("D", 15);

            var combinedItems = new List<Product>();
            combinedItems.Add(SkuC);
            combinedItems.Add(SkuD);

            var combinedPromotion = new CombinedPromotion(1, new DateTime(2021, 07, 01), new DateTime(2021, 12, 15), combinedItems, 30);
            var AmountPromotion1 = new AmountPromotion(2, new DateTime(2021, 07, 01), new DateTime(2021, 12, 15), SkuA, 3, 130);
            var AmountPromotion2 = new AmountPromotion(3, new DateTime(2021, 07, 01), new DateTime(2021, 12, 15), SkuB, 2, 45);

            List<Promotion> allPromotions = new List<Promotion>();
            allPromotions.Add(combinedPromotion);
            allPromotions.Add(AmountPromotion1);
            allPromotions.Add(AmountPromotion2);

            var cart1 = new Cart();
            cart1.CartItems.Add(SkuA, 1);
            cart1.CartItems.Add(SkuB, 1);
            cart1.CartItems.Add(SkuC, 1);

            var engine = new Engine();
            Assert.AreEqual(100, engine.GetTotalPrice(cart1, allPromotions));

            var cart2 = new Cart();
            cart2.CartItems.Add(SkuA, 5);
            cart2.CartItems.Add(SkuB, 5);
            cart2.CartItems.Add(SkuC, 1);

            Assert.AreEqual(370, engine.GetTotalPrice(cart2, allPromotions));

            var cart3 = new Cart();
            cart3.CartItems.Add(SkuA, 3);
            cart3.CartItems.Add(SkuB, 5);
            cart3.CartItems.Add(SkuC, 1);
            cart3.CartItems.Add(SkuD, 1);

            Assert.AreEqual(280, engine.GetTotalPrice(cart3, allPromotions));

        }
    }
}

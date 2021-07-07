using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Model;
using PromotionEngine.Model.Promotions;

namespace PromotionEngine_Test.Model.Promotions
{
    [TestClass]
    public class Promotion_Test
    {
        /// <summary>
        /// Create an old promotion and verify that it had expired
        /// </summary>
        [TestMethod]
        public void Promotion_Has_Expired()
        {
            var SkuA = new Product("A", 50);
            var promotion = new AmountPromotion(1, new DateTime(2020, 07, 01), new DateTime(2020, 12, 15), SkuA, 3, 130);
            Assert.IsFalse(promotion.PromotionValid());
        }

        /// <summary>
        /// Create an new promotion and verify that it is valid
        /// </summary>
        [TestMethod]
        public void Promotion_Is_Active()
        {
            var SkuA = new Product("A", 50);
            var promotion = new AmountPromotion(1, new DateTime(2019, 07, 01), new DateTime(2030, 12, 15), SkuA, 3, 130);
            Assert.IsTrue(promotion.PromotionValid());
        }
    }
}

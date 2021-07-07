using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model.Promotions
{
    class PercentagePromotion : Promotion, IPromotion
    {
        /// <summary>
        /// The percentage from 0-100 % to be applied for the product
        /// </summary>
        public decimal Percentage { get; set; }

        /// <summary>
        /// The product to be used in the promotion
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Create a new percentage promotion for a specific Sku
        /// </summary>
        /// <returns>A new percentage promotion type</returns>
        public PercentagePromotion(int id, DateTime start_date, DateTime end_date, Product product, decimal percentage) :
            base(id, start_date, end_date)
        {
            this.Product = product;
            this.Percentage = percentage;
        }

        public decimal CalculateDiscount(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}

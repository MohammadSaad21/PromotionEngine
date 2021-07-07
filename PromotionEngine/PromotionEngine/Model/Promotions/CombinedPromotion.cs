using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model.Promotions
{
    public class CombinedPromotion : Promotion, IPromotion
    {
        /// <summary>
        /// The list of product items to be used with the promotion
        /// </summary>
        public List<Product> CombintedItems { get; set; }

        /// <summary>
        /// The discount price for the promotion
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Create a new combined promotion that can contain multiple products
        /// </summary>

        /// <returns>An object witg new combined promotion type</returns>
        public CombinedPromotion(int id, DateTime start_date, DateTime end_date, List<Product> combintedItems, decimal discount) :
            base(id, start_date, end_date)
        {
            this.CombintedItems = combintedItems;
            this.Discount = discount;
        }

        public decimal CalculateDiscount(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}

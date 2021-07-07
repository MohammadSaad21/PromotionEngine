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

        /// <summary>
        /// Calculate the discount for the product items inside the cart
        /// </summary>
        /// <param name="cart">The cart which contains the added products </param>
        /// <returns>A decimalvalue, representing the discount after applying the promotion</returns>
        public decimal CalculateDiscount(Cart cart)
        {
            decimal discount = 0;
            decimal originalPrice = 0;
            int commonAmount = GetCommonAmount(cart);
            discount = GetCommonAmount(cart) * this.Discount;
            foreach (Product product in CombintedItems)
            {
                int amount;
                cart.CartItems.TryGetValue(product, out amount);
                int leftAmount = amount - commonAmount;

                discount += leftAmount * product.Unit_price;
                originalPrice += amount * product.Unit_price;
            }
            return originalPrice - discount;
        }

        /// <summary>
        /// Calculate the common amount between the products in the promotion list
        /// </summary>
        /// <returns>Amount common for the products inside the promotion list</returns>
        private int GetCommonAmount(Cart cart)
        {
            int commonAmount = 0;
            for (int i = 0; i < CombintedItems.Count; i++)
            {
                int amount;
                cart.CartItems.TryGetValue(CombintedItems[i], out amount);
                if (amount == 0)
                    return 0;
                if (amount < commonAmount || commonAmount == 0)
                    commonAmount = amount;
            }
            return commonAmount;
        }
    }
}

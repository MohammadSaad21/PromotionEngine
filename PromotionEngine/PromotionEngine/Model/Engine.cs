using PromotionEngine.Model.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class Engine
    {
        /// <summary>
        /// Create a list of the current active promotions
        /// </summary>
        /// <param name="allPromotions">The list of all the promotions in the system </param>
        /// <returns>A list with promotion objects</returns>
        private List<Promotion> GetActivePromotions(List<Promotion> allPromotions)
        {
            List<Promotion> activePromotions = new List<Promotion>();
            foreach (Promotion promotion in allPromotions)
                if (promotion.PromotionValid())
                    activePromotions.Add(promotion);
            return activePromotions;
        }

        /// <summary>
        /// Get the total discount price after applying all the active promotions in the cart
        /// </summary>
        /// <param name="cart">The cart which contains the added products</param>
        /// /// <param name="activePromotions">The list of active promotions </param>
        /// <returns>A decimal with the total discount inside the cart</returns>
        private decimal GetTotalDiscount(Cart cart, List<Promotion> activePromotions)
        {
            decimal discount = 0;

            foreach (IPromotion promotion in activePromotions)
            {
                discount += promotion.CalculateDiscount(cart);
            }

            return discount;
        }

        /// <summary>
        /// Get the total price in the cart after applying all the discounts
        /// </summary>
        /// <param name="cart">The cart which contains the added products</param>
        /// /// <param name="activePromotions">The list of all promotions </param>
        /// <returns>A decimal with the total price</returns>
        public decimal GetTotalPrice(Cart cart, List<Promotion> allPromotions)
        {
            decimal totalPrice = 0;

            var activePromotions = GetActivePromotions(allPromotions);
            var totalDiscount = GetTotalDiscount(cart, activePromotions);
            foreach (KeyValuePair<Product, int> item in cart.CartItems)
            {
                totalPrice += item.Value * item.Key.Unit_price;
            }

            return totalPrice - totalDiscount;
        }
    }
}

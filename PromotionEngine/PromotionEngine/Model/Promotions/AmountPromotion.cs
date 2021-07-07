using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model.Promotions
{
    public class AmountPromotion : Promotion, IPromotion
    {
        /// <summary>
        /// The required amount of the product item for the promotion to be applied
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The product to be used in the promotion
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// The discount price for the promotion
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Create a new amout promotion for a specific Sku
        /// </summary>
        /// <returns>A new amount promotion type</returns>
        public AmountPromotion(int id, DateTime start_date, DateTime end_date, Product product, int amount, decimal discount) :
            base(id, start_date, end_date)
        {
            this.Product = product;
            this.Amount = amount;
            this.Discount = discount;
        }

        /// <summary>
        /// Calculate the discount for the product items inside the cart
        /// </summary>
        /// <param name="cart">The cart which contains the added products </param>
        /// <returns>A decimalvalue, representing the discount after applying the promotion</returns>
        public decimal CalculateDiscount(Cart cart)
        {
            int amount = 0;
            cart.CartItems.TryGetValue(Product, out amount);
            if (amount >= this.Amount)
                return (amount * Product.Unit_price) - (Math.Floor((decimal)(amount / this.Amount)) * this.Discount + (amount % this.Amount) * Product.Unit_price);
            else
                return 0;
        }
    }
}

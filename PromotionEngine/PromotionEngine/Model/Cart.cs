using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class Cart
    {
        /// <summary>
        /// A dictionary containing product objects with the amount in the cart
        /// </summary>
        public Dictionary<Product, int> CartItems { get; set; }

        /// <summary>
        /// Create  an empty cart
        /// </summary>
        /// <returns>An empty dictionary cart</returns>
        public Cart()
        {
            this.CartItems = new Dictionary<Product, int>();
        }

        /// <summary>
        /// Adds a product to the cart with a specific amount
        /// </summary>
        /// <param name="product">The product to be added to the cart</param>
        /// <param name="amount">TThe amount of the product to be added</param>
        public void Add(Product product, int amount)
        {
            if (this.CartItems.ContainsKey(product))
            {
                int oldAmount = 0;
                CartItems.TryGetValue(product, out oldAmount);
                CartItems[product] = oldAmount + amount;
            }
            else
                CartItems.Add(product, amount);
        }

        /// <summary>
        /// Get the total items in the cart.
        /// </summary>
        public int GetTotalCount()
        {
            return CartItems.Count;
        }
    }
}

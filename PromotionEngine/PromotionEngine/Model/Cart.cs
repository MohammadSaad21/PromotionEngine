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
    }
}

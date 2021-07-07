using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model
{
    public class Product
    {
        /// <summary>
        /// A Sku Id for identitifying a specific product
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// A unit price for the product
        /// </summary>
        public decimal Unit_price { get; set; }

        /// <summary>
        /// A product constructur
        /// </summary>
        /// <returns>An product object containing Sku and unit price</returns>
        public Product(string sku, decimal unit_price)
        {
            this.Sku = sku;
            this.Unit_price = unit_price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model.Promotions
{
    interface IPromotion
    {
        /// <summary>
        /// Interface method that should be implemented by all the promotion types
        /// </summary>
        decimal CalculateDiscount(Cart cart);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Model.Promotions
{
    public class Promotion
    {
        /// <summary>
        /// A unique Id for the promotion
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A start date for the promotion
        /// </summary>
        public DateTime Start_date { get; set; }

        /// <summary>
        /// An end date for the promotion
        /// </summary>
        public DateTime End_date { get; set; }

        /// <summary>
        /// Base promotion constructur for all the promotion types
        /// </summary>
        public Promotion(int id, DateTime start_date, DateTime end_date)
        {
            this.Id = id;
            this.Start_date = start_date;
            this.End_date = end_date;
        }

        /// <summary>
        /// Verify if a promotion is still available
        /// </summary>
        /// <returns>A true value if the promotion is valid</returns>
        public bool PromotionValid()
        {
            if (Start_date < DateTime.Now && End_date > DateTime.Now)
                return true;
            else
                return false;
        }
    }
}

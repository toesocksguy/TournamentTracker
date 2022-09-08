using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// Unique identifier for a prize
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents this prize place number
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Represents this prize place name
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Represents this prize $$ amount
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Represents this prize percentage
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}

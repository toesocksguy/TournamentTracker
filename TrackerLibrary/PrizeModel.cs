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

        /// <summary>
        /// Empty PrizeModel
        /// </summary>
        public PrizeModel()
        {

        }

        /// <summary>
        /// Overloaded constructor for PrizeModel. Tries to parse arguments and set properties.
        /// </summary>
        /// <param name="placeName">Place name</param>
        /// <param name="placeNumber">Place number</param>
        /// <param name="prizeAmount">Prize amount</param>
        /// <param name="prizePercentage">Prize percentage</param>
        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}

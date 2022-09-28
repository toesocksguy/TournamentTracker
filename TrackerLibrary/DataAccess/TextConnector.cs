using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;


namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";

        // TODO - Make CreatePrize method actually save to text file
        /// <summary>
        /// Save a new prize to a text file.
        /// </summary>
        /// <param name="model">The prize info.</param>
        /// <returns>The prize info, including the unique ID.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the text file and convert string list to list of PrizeModel
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID by ordering by descending on the prizeID(using lambda expression) then get the first item and add 1
            int currentID = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            model.Id = currentID;

            // Add the new record with the new ID (max + 1)
            prizes.Add(model);

            // Convert the prizes to string list
            // Save the string list to text file
            prizes.SaveToPrizeFile(PrizesFile);
        }
    }
}

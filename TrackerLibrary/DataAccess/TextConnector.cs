using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        // TODO - Make CreatePrize method actually save to text file
        /// <summary>
        /// Save a new prize to a text file.
        /// </summary>
        /// <param name="model">The prize info.</param>
        /// <returns>The prize info, including the unique ID.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // TODO -Load the text file

            // TODO -Convert text to list of PrizeModel

            // TODO - Find the max ID

            // TODO - Add the new record with the new ID (max + 1)

            // TODO - Convert the prizes to string list

            // TODO - Save the string list to text file
        }
    }
}

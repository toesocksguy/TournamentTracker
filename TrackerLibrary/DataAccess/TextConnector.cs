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
        private const string PeopleFile = "PersonModels.csv";

        /// <summary>
        /// Save prizes to a text file.
        /// </summary>
        /// <param name="model">The prize info.</param>
        /// <returns>The prize info, including the unique ID.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the text file(get list of existing prizes) and convert string list to list of PrizeModel
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID by ordering by descending on the prizeID(using lambda expression) then get the first item and add 1
            int currentID = 1;
            if (prizes.Count > 0)
            {
                currentID = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentID;

            // Add the new record with the new ID (max + 1)
            prizes.Add(model);

            // Convert the prizes to string list
            // Save the string list to text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        /// <summary>
        /// Save people info to text file
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentID = 1;
            if (people.Count > 0)
            {
                currentID = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentID;

            people.Add(model);

            people.SaveToPeopleFile(PeopleFile);

            return model;
        }

        // TODO - Wire this up
        public List<PersonModel> GetPerson_All()
        {
            throw new NotImplementedException();
        }
    }
}

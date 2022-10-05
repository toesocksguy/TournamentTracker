using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// Use AppSettings key to get file path value then append filename.
        /// </summary>
        /// <param name="fileName">Name of text file</param>
        /// <returns></returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        /// <summary>
        /// Load the text file. If the file doesn't exist create new string list. If the file does exist return all lines from text file as string list.
        /// </summary>
        /// <param name="file">Text file</param>
        /// <returns></returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Converts data to list of PrizeModels
        /// </summary>
        /// <param name="lines">List of strings(prize info)</param>
        /// <returns>List of PrizeModel</returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                // Split each column on a comma
                string[] cols = line.Split(',');

                // Create new PrizeModel and set properties
                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);

                // Add PrizeModel to list of prizemodels
                output.Add(p);
            }
            
            return output;
        }

        /// <summary>
        /// Converts data to list of people
        /// </summary>
        /// <param name="lines">List of strings(people info)</param>
        /// <returns>List of PersonModel</returns>
        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber = cols[4];

                output.Add(p);
            }

            return output;
        }

        /// <summary>
        /// Save prize data to text file
        /// </summary>
        /// <param name="models">PrizeModels</param>
        /// <param name="fileName">The path of the file</param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        /// <summary>
        /// Save people data to text file
        /// </summary>
        /// <param name="models">PersonM</param>
        /// <param name="filename">The path of the file</param>
        public static void SaveToPeopleFile(this List<PersonModel> models, string filename)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel p in models)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellphoneNumber}");
            }

            File.WriteAllLines(filename.FullFilePath(), lines);
        }
    }
}

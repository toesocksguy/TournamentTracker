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
        // Load the text file

        // Convert text to list of PrizeModel

        // TODO - Find the max ID

        // TODO - Add the new record with the new ID (max + 1)

        // TODO - Convert the prizes to string list

        // TODO - Save the string list to text file

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
        /// Create a list of PrizeModels. Split lines on comma and add to list of PrizeModel.
        /// </summary>
        /// <param name="lines">List of lines</param>
        /// <returns></returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);

                output.Add(p);
            }
            
            return output;
        }

        /// <summary>
        /// Save prize data to text file
        /// </summary>
        /// <param name="models">PrizeModels</param>
        /// <param name="fileName">Filename</param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}

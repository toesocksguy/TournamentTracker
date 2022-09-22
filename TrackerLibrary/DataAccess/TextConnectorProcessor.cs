using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextConnector
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            // Use AppSettings key to get file path value then append filename
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
    }
}

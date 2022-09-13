using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Holds data connections
        /// Gives the option to save to multiple files (database, text, etc)
        /// Only methods within the GlobalConfig class can change the value (private set)
        /// </summary>
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        /// <summary>
        /// Initialize data connections
        /// </summary>
        /// <param name="database">The database information.</param>
        /// <param name="textFiles">The text file information.</param>
        public static void InitializeConnections(bool database, bool textFiles) 
        {
            // if older c# (4.6?) version intialize here
            //Connections = new List<IDataConnection>();

            if (database)
            {
                // TODO - setup SQL Connector properly
                SQLConnector sql = new SQLConnector();
                Connections.Add(sql);
            }
            if (textFiles)
            {
                // TODO - setup Text Connector properly
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}

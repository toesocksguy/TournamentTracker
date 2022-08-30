using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// Holds data connections
        /// Gives the option to save to multiple files (database, text, etc)
        /// Only methods within the GlobalConfig class can change the value (private set)
        /// </summary>
        public static List<IDataConnection> Connections { get; private set; }

        /// <summary>
        /// Initialize data connections
        /// </summary>
        /// <param name="database"></param>
        /// <param name="textFiles"></param>
        public static void InitializeConnections(bool database, bool textFiles) 
        {
            if (database)
            {
                // TODO - create SQL connection
            }
            if (textFiles)
            {
                // TODO - create the txt connection
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static IDataConnection Connection { get; private set; }

        /// <summary>
        /// Initialize database connection
        /// </summary>
        /// <param name="dbType">Database type</param>
        public static void InitializeConnections(DatabaseType dbType) 
        {
            // if older c# (4.6?) version intialize here
            //Connections = new List<IDataConnection>();

            if (dbType == DatabaseType.Sql)
            {
                // TODO - setup SQL Connector properly
                SQLConnector sql = new SQLConnector();
                Connection = sql;
            }
            else if (dbType == DatabaseType.Textfile)
            {
                // TODO - setup Text Connector properly
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}

using TrackerLibrary;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Initialize the database connections
            // TODO - change DatabaseType for  testing
            TrackerLibrary.GlobalConfig.InitializeConnections(DatabaseType.Textfile);

            //Application.Run(new TournamentDashboardForm());
            Application.Run(new CreateTeamForm());
        }
    }
}
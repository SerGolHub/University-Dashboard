using NLog;

namespace University_Dasboard
{
    internal static class Program
    {
		private static Logger logger = LogManager.GetCurrentClassLogger();
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMainProgram());
        }
    }
}
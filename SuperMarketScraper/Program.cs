using System.Text;

namespace SuperMarketScraper
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
            var path = CreateDirectory();
            Application.Run(new Form1(path));
        }

        public static string CreateDirectory()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docPath, "MarketScraperv2");
            Directory.CreateDirectory(path);
            return path;
        }

    }
}
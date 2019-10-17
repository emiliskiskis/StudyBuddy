using System;
using System.Windows.Forms;

namespace StudyBuddy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UserRating());
            //Application.Run(new Login());
            NetworkManager.Setup();
            Application.Run(new MainMenu());
        }
    }
}
using System;
using System.Windows.Forms;
using MainMenu = StudyBuddy.Forms.MainMenu;
using StudyBuddy.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace StudyBuddy
{
    internal class Program
    {
        private static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            using var formManager = new FormManager((NetworkManager)ServiceProvider.GetService(typeof(NetworkManager)));
            Application.Run(formManager);
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<NetworkManager>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}

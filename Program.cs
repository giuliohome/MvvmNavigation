using System;
using System.Windows;
using SimpleInjector;
using MvvmNavigation;
using System.Diagnostics;
using System.Windows.Input;
using System.Threading;
namespace MvvmNavigation
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var container = Bootstrap();

            // Any additional other configuration, e.g. of your desired MVVM toolkit.

            RunApplication(container);
        }

        private static Container Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:


            // Register your windows and view models:
            container.Register<MainWindow>(Lifestyle.Singleton);
            container.Register<MainWindowViewModel>(Lifestyle.Singleton);

            container.Verify();

            return container;
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var mainWindow = container.GetInstance<MainWindow>();
                var app = new App();
                app.InitializeComponent();
                app.Run(mainWindow);
            }
            catch (Exception ex)
            {
                //Log the exception and exit
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
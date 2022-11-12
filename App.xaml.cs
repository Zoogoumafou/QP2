using System.Diagnostics;
using System.Threading;
using System.Windows;
using QuickPing2.SplashScreen;
using QuickPing2.Windows;

namespace QuickPing2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 1500; // Miliseconds  

        protected override void OnStartup(StartupEventArgs e)
        {
            Splash splash = new Splash();
            splash.Show();
            // Step 2 - Start a stop watch  
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Step 3 - Load your windows but don't show it yet  
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            timer.Stop();

            int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            if (remainingTimeToShowSplash > 0)
                Thread.Sleep(remainingTimeToShowSplash);

            splash.Close();

        }

    }
}

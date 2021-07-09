using System.Windows;

namespace LazyRaid
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow main = new LazyRaid.MainWindow();
            main.Show();
        }
    }
}

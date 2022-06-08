using System.Windows;
using WeatherWidget.ViewModels;
using WeatherWidget.Views;

namespace WeatherWidget
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel().LoadData()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

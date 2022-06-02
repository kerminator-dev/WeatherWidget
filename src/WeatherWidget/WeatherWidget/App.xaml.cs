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
        private readonly MainWindowViewModel _mainWindowViewModel;
        public App() : base()
        {
            _mainWindowViewModel = new MainWindowViewModel();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _mainWindowViewModel.LoadData();
            MainWindow = new MainWindow()
            {
                DataContext = _mainWindowViewModel
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

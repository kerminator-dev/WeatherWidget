using System.Windows;
using System.Windows.Input;
using WeatherWidget.Models;

namespace WeatherWidget.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Мкнеджер погоды, выдающий данные
        /// </summary>
        private readonly OpenWeatherManager? _weatherManager;

        /// <summary>
        /// Результат с данными о погоде, получемый от OpenWeatherManager
        /// </summary>
        private readonly OpenWeatherResponce? _responce;

        public OpenWeatherResponce? Responce => _responce;

        /// <summary>
        /// Окно настроек
        /// </summary>
        private SettingsWindow _settingsWindow;
        public MainWindow()
        {
            InitializeComponent();
            
            _weatherManager = new OpenWeatherManager
            (
                city: "Krasnoperekopsk", 
                token: Properties.Settings.Default.APIKey
            );
            _responce = _weatherManager.GetResponce();

            UpdateViewData();
        }

        private void UpdateViewData()
        {
            if (_responce == null || _responce.Days.Count < 5)
                return;

            // Заполнние данными элементов слева
            CurrentDayOfWeek.Content = _responce.Days[0].WeatherStates[0].Date.DayOfWeek;
            CurrentDate.Content = _responce.Days[0].WeatherStates[0].Date.ToShortDateString();
            CurrentWeatherType.Content = _responce.Days[0].GetFrequentDescription();
            CurrentMinTemperature.Content = _responce.Days[0].GetMinTemperature() + "℃";
            CurrentMaxTemperature.Content = _responce.Days[0].GetMaxTemperature() + "℃";
            CurrentPlace.Content = $"{_responce.City.Name}, {_responce.City.Country}";

            // Заполнение элементов на панели справа
            Day1.UpdateViewData(_responce.Days[0]);
            Day2.UpdateViewData(_responce.Days[1]);
            Day3.UpdateViewData(_responce.Days[2]);
            Day4.UpdateViewData(_responce.Days[3]);
            Day5.UpdateViewData(_responce.Days[4]);
        }

        /// <summary>
        /// Перетаскивание формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (_settingsWindow == null)
                _settingsWindow = new SettingsWindow();

            _settingsWindow.Show();
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

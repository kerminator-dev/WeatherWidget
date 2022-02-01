using System.Windows.Controls;
using WeatherWidget.Models;

namespace WeatherWidget.Controls
{
    /// <summary>
    /// Логика взаимодействия для DayItemControl.xaml
    /// </summary>
    public partial class DayItemControl : UserControl
    {
        /// <summary>
        /// Данные о погоде за 1 день
        /// </summary>
        private OpenWeatherDay _dayInfo;

        /// <summary>
        /// Конструктор DayItemControl
        /// </summary>
        public DayItemControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор DayItemControl
        /// </summary>
        /// <param name="dayInfo">Данные о погоде за один день</param>
        public DayItemControl(OpenWeatherDay dayInfo)
        {
            InitializeComponent();

            UpdateViewData(dayInfo);
        }

        /// <summary>
        /// Обновить представление данных на контроле
        /// </summary>
        /// <param name="dayInfo">Данные о погоде за один день</param>
        public void UpdateViewData(OpenWeatherDay dayInfo)
        {
            _dayInfo = dayInfo;
            WeatherType.Content = _dayInfo.GetFrequentDescription();
            Temperature.Content = $"{_dayInfo.GetMinTemperature()}℃/{_dayInfo.GetMaxTemperature()}℃";
            Date.Content = _dayInfo.GetDate().ToShortDateString();
        }
    }
}

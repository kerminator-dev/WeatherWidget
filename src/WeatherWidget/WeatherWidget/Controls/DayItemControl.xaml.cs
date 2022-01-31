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

        public DayItemControl()
        {
            InitializeComponent();
        }

        public void UpdateViewData(OpenWeatherDay dayInfo)
        {
            _dayInfo = dayInfo;
            WeatherType.Content = _dayInfo.GetFrequentDescription();
            Temperature.Content = $"{_dayInfo.GetMinTemperature()}℃/{_dayInfo.GetMaxTemperature()}℃";
            Date.Content = _dayInfo.Date.ToShortDateString();
        }
    }
}

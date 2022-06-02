using WeatherWidget.Helpers;

namespace WeatherWidget.ViewModels
{
    public class DayControlViewModel
    {
        private readonly OpenWeatherDay _openWeatherDay;

        public string WeatherType => _openWeatherDay.GetFrequentDescription();
        public string Temperature => $"{_openWeatherDay.GetMinTemperature()}℃/{_openWeatherDay.GetMaxTemperature()}℃";
        public string Date => _openWeatherDay.GetDate().ToShortDateString();

        public DayControlViewModel(OpenWeatherDay openWeatherDay)
        {
            _openWeatherDay = openWeatherDay;
        }
    }
}

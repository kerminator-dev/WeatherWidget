using System.Collections.Generic;
using WeatherWidget.Helpers;
using WeatherWidget.ViewModels;
using WeatherWidget.Views;

namespace WeatherWidget.Converters
{
    public static class Converter
    {
        public static IEnumerable<DayItemControl> ToDayControls(IEnumerable<OpenWeatherDay> openWeatherDays)
        {
            List<DayItemControl> result = new List<DayItemControl>();

            foreach (var day in openWeatherDays)
            {
                var control = new DayItemControl();
                control.DataContext = new DayControlViewModel(day);
                result.Add(control);
            }

            return result;
        }
    }
}

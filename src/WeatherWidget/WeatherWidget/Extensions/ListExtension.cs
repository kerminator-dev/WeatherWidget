using System.Collections.Generic;
using WeatherWidget.Helpers;
using WeatherWidget.ViewModels;
using WeatherWidget.Views;

namespace WeatherWidget.Extensions
{
    public static class ListExtension
    {
        public static IReadOnlyList<DayItemControl> ToDayControls(this IReadOnlyList<OpenWeatherDay> openWeatherDays)
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

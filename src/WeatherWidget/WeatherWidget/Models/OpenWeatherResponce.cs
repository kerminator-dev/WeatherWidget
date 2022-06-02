using System.Collections.Generic;
using WeatherWidget.Helpers.JSON;

namespace WeatherWidget.Helpers
{
    /// <summary>
    /// Данные о погоде
    /// </summary>
    public partial class OpenWeatherResponce
    {
        /// <summary>
        /// Список дней с данными о погоде
        /// </summary>
        private readonly List<OpenWeatherDay> _days;

        public IReadOnlyList<OpenWeatherDay> Days => _days.AsReadOnly();

        /// <summary>
        /// Данные о городе
        /// </summary>
        public JSONCity City { get; private set; }

        /// <summary>
        /// Данные о погоде
        /// </summary>
        /// <param name="days">Спиоск дней с данными о погоде</param>
        /// <param name="city">Данные о городе</param>
        public OpenWeatherResponce(List<OpenWeatherDay> days, JSONCity city)
        {
            _days = days;
            City = city;
        }
    }
}

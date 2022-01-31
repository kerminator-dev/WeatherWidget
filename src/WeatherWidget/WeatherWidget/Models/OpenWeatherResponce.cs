using System.Collections.Generic;

namespace WeatherWidget.Models
{
    /// <summary>
    /// Готовый класс - результат для работы с данными о погоде
    /// </summary>
    public class OpenWeatherResponce
    {
        /// <summary>
        /// Список дней с данными о погоде
        /// </summary>
        private readonly List<OpenWeatherDay> _days;

        public IReadOnlyList<OpenWeatherDay> Days => _days.AsReadOnly();

        /// <summary>
        /// Данные о городе
        /// </summary>
        public City City { get; private set; }

        /// <summary>
        /// Констурктор OpenWeatherResponce
        /// </summary>
        /// <param name="days">Спиоск дней с данными о погоде</param>
        /// <param name="city">Данные о городе</param>
        public OpenWeatherResponce(List<OpenWeatherDay> days, City city)
        {
            _days = days;
            City = city;
        }
    }
}

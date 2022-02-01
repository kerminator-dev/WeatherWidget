using System;

namespace WeatherWidget.Models
{
    /// <summary>
    /// Состояние погоды (каждый объект должен представлять данные о погоде с интервалом в 3 часа)
    /// </summary>
    public partial class OpenWeatherState
    {
        /// <summary>
        /// Минимальная температура
        /// </summary>
        public double MinTemperature { get; set; }

        /// <summary>
        /// Максимальная температура
        /// </summary>
        public double MaxTemperature { get; set; }

        /// <summary>
        /// Тип погоды
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата и время
        /// </summary>
        public DateTime Date { get; set; }

        public OpenWeatherState(double minTemperature, double maxTemperature, string description, DateTime date)
        {
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            Description = description;
            Date = date;
        }
    }
}

using System;

namespace WeatherWidget.Helpers
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
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Состояние погоды
        /// </summary>
        /// <param name="minTemperature">Минимальная температура</param>
        /// <param name="maxTemperature">Максимальная температура</param>
        /// <param name="description">Тип погоды</param>
        /// <param name="date">Дата и  время</param>
        public OpenWeatherState(double minTemperature, double maxTemperature, string description, DateTime dateTime)
        {
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
            Description = description;
            DateTime = dateTime;
        }
    }
}

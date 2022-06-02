using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherWidget.Helpers
{
    /// <summary>
    /// Данные о погоде за день
    /// </summary>
    public class OpenWeatherDay
    {
        /// <summary>
        /// Состояния погоды на каждые 3 часа
        /// </summary>
        public List<OpenWeatherState> WeatherStates { get; private set; }

        /// <summary>
        /// Конструктор OpenWeatherDay
        /// </summary>
        /// <param name="weatherStates"></param>
        public OpenWeatherDay(List<OpenWeatherState> weatherStates)
        {
            WeatherStates = weatherStates;
        }

        /// <summary>
        /// Получить среднюю температуру за день
        /// </summary>
        /// <returns>Средняя температура за день</returns>
        public double GetAVGTemp()
        {
            return (GetMinTemperature() + GetMaxTemperature()) / 2;
        }

        /// <summary>
        /// Получить минимальную температуру за день
        /// </summary>
        /// <returns>Минимальная температура за день</returns>
        public double GetMinTemperature(bool round = true)
        {
            double result = WeatherStates[0].MinTemperature;

            foreach (OpenWeatherState weather in WeatherStates)
            {
                if (result > weather.MinTemperature)
                {
                    result = weather.MinTemperature;
                }
            }

            return round ? Math.Round(result) : result;
        }

        /// <summary>
        /// Получить максимальную температуру за день
        /// </summary>
        /// <returns>Минимальная температура за день</returns>
        public double GetMaxTemperature(bool round = true)
        {
            double result = WeatherStates[0].MinTemperature;

            foreach (OpenWeatherState weather in WeatherStates)
            {
                if (result < weather.MinTemperature)
                {
                    result = weather.MinTemperature;
                }
            }

            return round ? Math.Round(result) : result;
        }

        /// <summary>
        /// Получить дату
        /// </summary>
        /// <returns>Дата DateTime</returns>
        public DateTime GetDate()
        {
            return new DateTime(WeatherStates[0].DateTime.Year, WeatherStates[0].DateTime.Month, WeatherStates[0].DateTime.Day);
        }

        /// <summary>
        /// Получить все частоповторяющиеся типы погоды за день 
        /// по убыванию
        /// </summary>
        /// <returns></returns>
        public string GetUniqueDescriptions()
        {
            // Получение уникальных типов погоды по убыванию
            var uniqueDescription = WeatherStates.OrderByDescending(i => i.Description).DistinctBy(j => j.Description).ToList();
            string result = string.Empty;

            if (uniqueDescription.Count > 0)
            {
                for (int i = 0; i < uniqueDescription.Count - 1; i++)
                {
                    result += $"{uniqueDescription[i]}, ";
                }
                result += uniqueDescription[uniqueDescription.Count - 1];
            }

            return result;
        }

        /// <summary>
        /// Получить частоповторяющийся тип погоды за день
        /// </summary>
        /// <returns></returns>
        public string GetFrequentDescription()
        {
            var uniqueWeatherStatess = WeatherStates.OrderByDescending(i => i.Description).DistinctBy(j => j.Description).ToList();

            if (uniqueWeatherStatess.Count > 0)
            {
                return $"{uniqueWeatherStatess[0].Description}";
            }
            else return "no weather data";
        }
    }
}

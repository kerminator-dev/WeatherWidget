using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherWidget.Models
{
    /// <summary>
    /// Данные о погоде за день
    /// </summary>
    public class OpenWeatherDay
    {
        /// <summary>
        /// Минимальная температура (каждые 3 часа)
        /// </summary>
        public List<double> MinTemperatures { get; set; }

        /// <summary>
        /// Максимальная температура (каждые 3 часа)
        /// </summary>
        public List<double> MaxTemperatures { get; set; }

        /// <summary>
        /// Тип погоды (каждые 3 часа)
        /// </summary>
        public List<string> Descriptions { get; set; } 

        /// <summary>
        /// День в формате даты
        /// </summary>
        public DateTime Date { get; set; }

        public OpenWeatherDay()
        {
            MinTemperatures = new List<double>();
            MaxTemperatures = new List<double>();
            Descriptions = new List<string>();
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
            double result = MinTemperatures[0];

            foreach (double temp in MinTemperatures)
                if (result > temp)
                    result = temp;

            return round ? Math.Round(result) : result;
        }

        /// <summary>
        /// Получить максимальную температуру за день
        /// </summary>
        /// <returns>Минимальная температура за день</returns>
        public double GetMaxTemperature(bool round = true)
        {
            double result = MaxTemperatures[0];

            foreach (double temp in MaxTemperatures)
                if (result < temp)
                    result = temp;

            return round ? Math.Round(result) : result;
        }

        /// <summary>
        /// Получить все частоповторяющиеся типы погоды за день 
        /// по убыванию
        /// </summary>
        /// <returns></returns>
        public string GetUniqueDescriptions()
        {
            var uniqueDescription = Descriptions.OrderByDescending(i => i).Distinct<string>().ToList();
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
            var uniqueDescription = Descriptions.OrderByDescending(i => i).Distinct<string>().ToList();

            if (uniqueDescription.Count > 0)
            {
                return $"{uniqueDescription[0]}";
            }
            else return "no weather data";
        }
    }
}

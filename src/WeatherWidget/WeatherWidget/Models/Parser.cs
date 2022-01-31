using System;
using System.Collections.Generic;

namespace WeatherWidget.Models
{
    public static class Parser
    {
        /// <summary>
        /// Преобразовать полученный от сервреа десереализованный объект в объект более удобного типа OpenWeatherResponce
        /// с данными о погоде не за каждые 3 часа, а за каждый день
        /// </summary>
        /// <returns>Данные о погоде с более удобной структурой</returns>
        public static OpenWeatherResponce? ToOpenWeatherResponce(in JSONResponce responce)
        {
            if (responce == null || responce.Items.Count < 5) return null;

            var result = new List<OpenWeatherDay>();

            // 0 элемент
            int counter = 1;
            int day = DateTime.Parse(responce.Items[0].dt_txt).Day;
            var temp = new OpenWeatherDay();
            temp = Merge(temp, responce.Items[0]);

            for (int i = 1; i < responce.Items.Count; i++)
            {
                // Сравнение дня
                int tempDay = DateTime.Parse(responce.Items[i].dt_txt).Day;
                if (day == tempDay)
                {
                    // Если у элемента день всё тот же, то добавляется данные за это время
                    temp = Merge(temp, responce.Items[i]);
                    counter++;
                }
                else
                {
                    // Если у элемента день следующий, то создаётся новый день и в него добавляются данные
                    result.Add(temp);
                    counter = 1;
                    temp = new OpenWeatherDay();
                    temp = Merge(temp, responce.Items[i]);
                    day = tempDay;
                }
            }

            return new OpenWeatherResponce(result, responce.City);
        }

        /// <summary>
        /// Добавление/слияние данных о погоде за каждые 3 часа в один день
        /// Т. к. сервер возрващает данные о погоде не за день, а за каждые 3 часа.
        /// </summary>
        /// <param name="day">Данные о погоде за день</param>
        /// <param name="item">Данные о погоде за каждые 3 часа</param>
        /// <returns>Объект с данными о погоде за день</returns>
        private static OpenWeatherDay Merge(in OpenWeatherDay day, in ListItem item)
        {
            day.MinTemperatures.Add(item.MainInfo.Temp_min);
            day.MaxTemperatures.Add(item.MainInfo.Temp_max);
            day.Descriptions.Add(item.Weathers[0].Description);
            day.Date = DateTime.Parse(item.dt_txt);

            return day;
        }
    }
}

using System;
using System.Collections.Generic;
using WeatherWidget.Helpers;
using WeatherWidget.Helpers.JSON;

namespace WeatherWidget.Converters
{
    public static class JsonConverter
    {
        /// <summary>
        /// Конвертировать десириализованный JSON объект типа JSONResponce, полученный с сервера OpenWeatherMap, в объект типа OpenWeatherResponce
        /// </summary>
        /// <param name="jsonResponce">Десириализованный JSON объект, полученный с сервера OpenWeatherMap</param>
        /// <param name="responce">Преобразованный объект типа JSONResponce в объект типа OpenWeatherResponce</param>
        /// <returns>true - преобразование успешно выполнено, false - не удалось преобразовать</returns>
        public static OpenWeatherResponce? ToOpenWeatherResponce(JSONResponce jsonResponce)
        {
            if (jsonResponce == null) return null;

            try
            {
                // Ежедневная информация о погоде
                List<OpenWeatherDay> days = new List<OpenWeatherDay>();
                // Состояния о погоде (каждый элемент с интервалом в 3 часа)
                List<OpenWeatherState> weatherStates = new List<OpenWeatherState>();
                // День прошлого элемента (нужен для сравнения дат)
                int lastItemDay = DateTime.Parse(jsonResponce.Items[0].DateTime).Day;
                // День текущего элемента (нужен для сравнения дат)
                int currentItemDay;

                // Группировка состояний погоды за каждые 3 часа в дни
                // В каждом дне до 8 состояний погоды (3 часа * 8 = 24 часа)
                foreach (var item in jsonResponce.Items)
                {
                    currentItemDay = DateTime.Parse(item.DateTime).Day;

                    if (lastItemDay == currentItemDay)
                    {
                        weatherStates.Add(ToWeatherState(item));
                    }
                    else
                    {
                        // Создание дня и добавление ранее обработаннх состояний погоды за этот день
                        days.Add(new OpenWeatherDay(weatherStates));
                        weatherStates = new List<OpenWeatherState>();
                        // Обработка состояния погоды за новый день
                        weatherStates.Add(ToWeatherState(item));
                        lastItemDay = currentItemDay;
                    }
                }

                return new OpenWeatherResponce(days, jsonResponce.City);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Преобразовать объект типа ListItem в объект WeatherState
        /// </summary>
        /// <param name="item">Данные о погоде (за каждый е 3 часа)</param>
        /// <returns></returns>
        public static OpenWeatherState ToWeatherState(JSONListItem item)
        {
            return new OpenWeatherState
            (
                minTemperature: item.MainInfo.Temp_min,
                maxTemperature: item.MainInfo.Temp_max,
                description: item.WeatherTypes[0].Description,
                dateTime: DateTime.Parse(item.DateTime)
            );
        }
    }
}

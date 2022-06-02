using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherWidget.Helpers.JSON
{
    /// <summary>
    /// Ответ от сервера OpenWeatherMap
    /// Данный класс повторяет структуру получаемого JSON-файла
    /// JSON десереализируется в объект этого типа
    /// </summary>
    public class JSONResponce
    {
        /// <summary>
        /// Список из обхектов - данных на каждые 3 часа
        /// </summary>
        [JsonProperty("list")]
        internal List<JSONListItem> Items { get; set; }

        /// <summary>
        /// Данные о городе
        /// </summary>
        [JsonProperty("city")]
        internal JSONCity City { get; set; }
    }

    /// <summary>
    /// Данные о погоде каждые 3 часа
    /// </summary>
    public class JSONListItem
    {
        [JsonProperty("main")]
        public JSONMainInfo MainInfo { get; set; }

        /// <summary>
        /// Список, состоящий из типов погоды (обычно 1 тип погоды)
        /// </summary>
        [JsonProperty("weather")]
        public List<JSONWeatherType> WeatherTypes { get; set; }

        /// <summary>
        /// Дата в формате строки
        /// </summary>
        [JsonProperty("dt_txt")]
        public string DateTime { get; set; }
    }

    /// <summary>
    /// Данные о температуре
    /// </summary>
    public class JSONMainInfo
    {
        /// <summary>
        /// Минимальная температура
        /// </summary>
        [JsonProperty("temp_min")]
        public double Temp_min { get; set; }

        /// <summary>
        /// Максимальная температура
        /// </summary>
        [JsonProperty("temp_max")]
        public double Temp_max { get; set; }
    }

    /// <summary>
    /// Данные о типе погоды
    /// </summary>
    public class JSONWeatherType
    {
        /// <summary>
        /// Тип погоды
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Данные о указанном городе
    /// </summary>
    public class JSONCity
    {
        /// <summary>
        /// Название города
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
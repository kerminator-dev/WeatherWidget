using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherWidget.Models.JSON
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

        [JsonProperty("weather")]
        public List<JSONWeatherType> WeatherTypes { get; set; }

        [JsonProperty("dt_txt")]
        public string dt_txt { get; set; }
    }

    /// <summary>
    /// Данные о температуре
    /// </summary>
    public class JSONMainInfo
    {
        [JsonProperty("temp_min")]
        public double Temp_min { get; set; }

        [JsonProperty("temp_max")]
        public double Temp_max { get; set; }
    }

    /// <summary>
    /// Данные о типе погоды
    /// </summary>
    public class JSONWeatherType
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Данные о указанном городе
    /// </summary>
    public class JSONCity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
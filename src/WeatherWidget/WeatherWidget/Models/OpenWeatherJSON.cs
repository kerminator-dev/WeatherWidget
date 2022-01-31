using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherWidget.Models
{
    /// <summary>
    /// Ответ от сервера OpenWeather
    /// Данный класс повторяет структуру получаемого JSON-файла
    /// JSON десереализируется в объект этого класса
    /// </summary>
    public class JSONResponce
    {
        /// <summary>
        /// Список из обхектов - данных на каждые 3 часа
        /// </summary>
        [JsonProperty("list")]
        internal List<ListItem> Items { get; set; }

        /// <summary>
        /// Данные о городе
        /// </summary>
        [JsonProperty("city")]
        internal City City { get; set; }
    }

    /// <summary>
    /// Данные о погоде каждые 3 часа
    /// </summary>
    public class ListItem
    {
        [JsonProperty("main")]
        public MainInfo MainInfo { get; set; }

        [JsonProperty("weather")]
        public List<WeatherInfo> Weathers { get; set; }

        [JsonProperty("dt_txt")]
        public string dt_txt { get; set; }
    }

    /// <summary>
    /// Данные о температуре
    /// </summary>
    public class MainInfo
    {
        [JsonProperty("temp_min")]
        public double Temp_min { get; set; }

        [JsonProperty("temp_max")]
        public double Temp_max { get; set; }
    }

    /// <summary>
    /// Данные о типе погоды
    /// </summary>
    public class WeatherInfo
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Данные о указанном городе
    /// </summary>
    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
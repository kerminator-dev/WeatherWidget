using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using WeatherWidget.Helpers.JSON;

namespace WeatherWidget.Helpers
{
    /// <summary>
    /// Главный менеджер для работы с OpenWeatherMap API
    /// </summary>
    public class OpenWeatherManager
    {
        /// <summary>
        /// Город
        /// </summary>
        private string _city;

        /// <summary>
        /// Город
        /// </summary>
        public string City
        {
            get => _city;
            private set
            {
                _city = value;

                // Обновление URL
                _url = $"http://api.openweathermap.org/data/2.5/forecast?q={value}&lang=en-us&units=metric&appid={_apiKey}";
            }
        }

        /// <summary>
        /// Полный адрес для получения данных от API OpenWeather
        /// </summary>
        private string _url;

        /// <summary>
        /// API-ключ/токен для доступа к API OpenWeatherMap
        /// </summary>
        private string _apiKey { get; set; }

        /// <summary>
        /// Главный менеджер для работы с OpenWeatherMap API
        /// </summary>
        /// <param name="city">Город</param>
        /// <param name="apiKey">Токен для доступа к API OpenWeatherMap</param>
        public OpenWeatherManager(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// Получить данные о погоде
        /// </summary>
        /// <returns>Объект OpenWeatherResponce - данные о погоде</returns>
        public OpenWeatherResponce? GetWeatherData(string city)
        {
            this.City = city;
            return Converters.JsonConverter.ToOpenWeatherResponce(this.GetJSONResponce());
        }

        /// <summary>
        /// Получить JSON с данными о погоде
        /// </summary>
        /// <returns>Данные о погоде JSONResponce</returns>
        private JSONResponce? GetJSONResponce()
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string responce = String.Empty;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    responce = streamReader.ReadToEnd();
                }

                httpWebResponse.Close();

                return JsonConvert.DeserializeObject<JSONResponce>(responce);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Проверка URL на правильность
        /// </summary>
        /// <param name="URL">Полный адрес к серверу и API-методу с параметрами</param>
        /// <returns>true - URL имеет верный формат и сервер вернул ответ, false - сервер не ответил</returns>
        private static bool IsValidURL(string URL)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                httpWebResponse.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

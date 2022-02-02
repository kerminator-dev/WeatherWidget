using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherWidget.Models.JSON;

namespace WeatherWidget.Models
{
    /// <summary>
    /// Главный менеджер для работы с OpenWeatherMap API
    /// </summary>
    public class OpenWeatherManager
    {
        /// <summary>
        /// Полный адрес для получения данных от API OpenWeather
        /// </summary>
        private string _url { get; set; }

        /// <summary>
        /// Инициализировать OpenWeatherManager
        /// </summary>
        /// <param name="city">город</param>
        /// <param name="token">токен для доступа к API OpenWeatherMap</param>
        public OpenWeatherManager(string city, string token)
        {
            _url = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&lang=en-us&units=metric&appid={token}";
        }

        /// <summary>
        /// Получить данные о погоде
        /// </summary>
        /// <returns>Объект OpenWeatherResponce - данные о погоде</returns>
        public async Task<OpenWeatherResponce?> GetResponce()
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

                JSONResponce objResponce = JsonConvert.DeserializeObject<JSONResponce>(responce);

                return Convert.ToOpenWeatherResponce(objResponce);
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
        private static bool IsValidURL(in string URL)
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

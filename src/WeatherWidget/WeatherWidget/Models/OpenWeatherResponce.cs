using System.Collections.Generic;

namespace WeatherWidget.Models
{
    public class OpenWeatherResponce
    {
        private readonly List<OpenWeatherDay> _days;
        public IReadOnlyList<OpenWeatherDay> Days
        {
            get 
            {
                return _days.AsReadOnly(); 
            }
        }

        public City City { get; private set; }

        public OpenWeatherResponce(List<OpenWeatherDay> days, City city)
        {
            _days = days;
            City = city;
        }
    }
}

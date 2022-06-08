using System.Collections.Generic;
using System.Windows.Input;
using WeatherWidget.Commands.MainWindowCommands;
using WeatherWidget.Extensions;
using WeatherWidget.Helpers;
using WeatherWidget.Views;

namespace WeatherWidget.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Поля
        /// <summary>
        /// Результат с данными о погоде, получемый от OpenWeatherManager
        /// </summary>
        private OpenWeatherResponce? _responce;
        #endregion

        #region Свойства
        // public IEnumerable<DayItemControl> DayControls => Converter.ToDayControls(_responce?.Days) ?? new List<DayItemControl>();
        public IReadOnlyList<DayItemControl> DayControls => _responce?.Days.ToDayControls();
        public string CurrentPlace => $"{_responce?.City.Name}, {_responce?.City.Country}";
        public string CurrentMaxTemperature => $"{_responce?.Days[0].GetMaxTemperature()} ℃";
        public string CurrentMinTemperature => $"{_responce?.Days[0].GetMinTemperature()} ℃";
        public string CurrentWeatherType => _responce?.Days[0].GetFrequentDescription() ?? string.Empty;
        public string CurrentDate => _responce?.Days[0].WeatherStates[0].DateTime.ToShortDateString() ?? string.Empty;
        public string CurrentDayOfWeek => _responce?.Days[0].WeatherStates[0].DateTime.DayOfWeek.ToString() ?? string.Empty;

        public ICommand LoadWeatherDataCommand { get; }
        #endregion

        public MainWindowViewModel()
            : this(Properties.Settings.Default.APIKey) { }

        public MainWindowViewModel(string apiKey)
        {
            var weatherManager = new OpenWeatherManager(apiKey);
            _responce = new OpenWeatherResponce
            (
                days: new List<OpenWeatherDay>(),
                city: new Helpers.JSON.JSONCity()
            );

            LoadWeatherDataCommand = new LoadWeatherDataCommand(this, weatherManager);
        }

        #region Методы
        private void OnResponceChanged()
        {
            // Уведомление GUI о том, что данные обновились
            OnPropertyChanged(nameof(DayControls));
            OnPropertyChanged(nameof(CurrentPlace));
            OnPropertyChanged(nameof(CurrentMaxTemperature));
            OnPropertyChanged(nameof(CurrentMinTemperature));
            OnPropertyChanged(nameof(CurrentWeatherType));
            OnPropertyChanged(nameof(CurrentDate));
            OnPropertyChanged(nameof(CurrentDayOfWeek));
        }

        public MainWindowViewModel LoadData()
        {
            LoadWeatherDataCommand.Execute(null);

            return this;
        }

        public void UpdateResponce(OpenWeatherResponce responce)
        {
            _responce = responce;

            OnResponceChanged();
        }
        #endregion
    }
}

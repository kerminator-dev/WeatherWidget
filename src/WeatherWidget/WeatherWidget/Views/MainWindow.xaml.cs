﻿using System.Windows;
using System.Windows.Input;
using WeatherWidget.Models;

namespace WeatherWidget.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Мкнеджер погоды, выдающий данные
        /// </summary>
        private OpenWeatherManager? _weatherManager;

        /// <summary>
        /// Результат с данными о погоде, получемый от OpenWeatherManager
        /// </summary>
        private OpenWeatherResponce? _responce;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обновить данные о погоде
        /// </summary>
        private void UpdateWeatherData()
        {
            _weatherManager = new OpenWeatherManager
            (
                apiKey: Properties.Settings.Default.APIKey
            );

            _responce = _weatherManager.GetWeatherData
            (
                city: Properties.Settings.Default.CurrentCity
            );

            if (_responce == null)
            {
                MessageBox.Show("Failed to get data from OpenWeatherMap server!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обновить представление окна в соответствии с полученными данными _responce
        /// </summary>
        private void UpdateViewData()
        {
            if (_responce == null || _responce.Days.Count < 5)
                return;

            // Заполнние данными элементов слева
            CurrentDayOfWeek.Content = _responce.Days[0].WeatherStates[0].DateTime.DayOfWeek;
            CurrentDate.Content = _responce.Days[0].WeatherStates[0].DateTime.ToShortDateString();
            CurrentWeatherType.Content = _responce.Days[0].GetFrequentDescription();
            CurrentMinTemperature.Content = _responce.Days[0].GetMinTemperature() + "℃";
            CurrentMaxTemperature.Content = _responce.Days[0].GetMaxTemperature() + "℃";
            CurrentPlace.Content = $"{_responce.City.Name}, {_responce.City.Country}";

            // Заполнение элементов на панели справа
            Day1.UpdateViewData(_responce.Days[0]);
            Day2.UpdateViewData(_responce.Days[1]);
            Day3.UpdateViewData(_responce.Days[2]);
            Day4.UpdateViewData(_responce.Days[3]);
            Day5.UpdateViewData(_responce.Days[4]);
        }

        /// <summary>
        /// Перетаскивание формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow.Instance.Close();
            this.Close();
        }

        /// <summary>
        /// Кнопка "Настройки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow.Instance.Show();
        }

        /// <summary>
        /// Кнопка "Скрыть окно"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Кнопка "Обновить данные"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateWeatherData();
            UpdateViewData();
        }
    }
}

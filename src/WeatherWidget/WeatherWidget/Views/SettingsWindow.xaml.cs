using System.Windows;
using System.Windows.Input;
using WeatherWidget.ViewModels;

namespace WeatherWidget.Views
{
    public partial class SettingsWindow : Window
    {
        #region Реализация Singleton

        private static SettingsWindow _instance;

        public static SettingsWindow Instance
        {
            get
            {
                return _instance ?? (_instance = new SettingsWindow());
            }
        }

        #endregion

        /// <summary>
        /// Окно настроек
        /// </summary>
        private SettingsWindow()
        {
            InitializeComponent();
            DataContext = new SettingsWindowViewModel();
        }

        /// <summary>
        /// Перетаскивание окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Сохранение настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}

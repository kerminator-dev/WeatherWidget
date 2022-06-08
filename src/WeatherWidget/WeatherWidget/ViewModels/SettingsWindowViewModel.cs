using System.Windows.Input;
using WeatherWidget.Commands.SettingsWindowCommands;

namespace WeatherWidget.ViewModels
{
    public class SettingsWindowViewModel
    {
        public ICommand SaveChangesCommand { get; }

        public string CurrentCity
        {
            get => Properties.Settings.Default.CurrentCity;
            set => Properties.Settings.Default.CurrentCity = value;
        }

        public SettingsWindowViewModel()
        {
            SaveChangesCommand = new SaveChangesCommand();
        }
    }
}

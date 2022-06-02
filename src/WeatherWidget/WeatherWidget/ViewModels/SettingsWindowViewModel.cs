using System.Windows.Input;
using WeatherWidget.Commands.SettingsWindowCommands;

namespace WeatherWidget.ViewModels
{
    public class SettingsWindowViewModel
    {
        public ICommand SaveChangesCommand { get; }

        public SettingsWindowViewModel()
        {
            SaveChangesCommand = new SaveChangesCommand();
        }
    }
}

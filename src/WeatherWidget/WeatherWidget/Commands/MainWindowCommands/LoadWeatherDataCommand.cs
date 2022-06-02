using WeatherWidget.Helpers;
using WeatherWidget.ViewModels;

namespace WeatherWidget.Commands.MainWindowCommands;

public class LoadWeatherDataCommand : CommandBase
{
    private readonly MainWindowViewModel _viewModel;
    private readonly OpenWeatherManager _weatherManager;
    public LoadWeatherDataCommand(MainWindowViewModel mainWindowViewModel, OpenWeatherManager weatherManager)
    {
        _viewModel = mainWindowViewModel;
        _weatherManager = weatherManager;
    }

    public override void Execute(object? parameter)
    {
        var weatherResponce = _weatherManager.GetWeatherData(Properties.Settings.Default.CurrentCity);

        _viewModel.UpdateResponce(weatherResponce);
    }
}

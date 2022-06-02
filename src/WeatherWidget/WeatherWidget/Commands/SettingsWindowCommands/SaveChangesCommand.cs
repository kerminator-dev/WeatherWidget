namespace WeatherWidget.Commands.SettingsWindowCommands;

public class SaveChangesCommand : CommandBase
{
    public override void Execute(object? parameter)
    {
        Properties.Settings.Default.Save();
    }
}

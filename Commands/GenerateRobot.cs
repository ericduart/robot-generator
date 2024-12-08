using System.Windows.Input;

namespace robot_generator.Commands;

public class GenerateRobot: ICommand
{

    private Action<string> _action;

    public GenerateRobot(Action<string> action)
    {
        _action = action;
    }
    
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        string randomGuid = Guid.NewGuid().ToString();
        _action($"https://robohash.org/{randomGuid}");
    }

    public event EventHandler? CanExecuteChanged;
}
using System.Windows.Input;

namespace robot_generator.Commands;

public class GenerateRobotCommand: ICommand
{

    private Action<string> _action;

    public GenerateRobotCommand(Action<string> action)
    {
        _action = action;
    }
    
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        string randomGuid = Guid.NewGuid().ToString();
        _action(randomGuid);
    }

    public event EventHandler? CanExecuteChanged;
}
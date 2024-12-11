using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace robot_generator.Commands;

public class AddRobotToFavoriteCommand : ICommand
{
    
    private readonly Action _saveRobotPath;

    public AddRobotToFavoriteCommand(Action saveRobotPath)
    {
        _saveRobotPath = saveRobotPath;
    }
    
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        if (parameter is MouseButtonEventArgs { Source: Path p })
        {
            p.Fill = Brushes.Gold;
            p.Stroke = Brushes.Gold;
        }

        _saveRobotPath?.Invoke();

    }

    public event EventHandler? CanExecuteChanged;
}
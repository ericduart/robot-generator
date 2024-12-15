using System.Windows.Input;

namespace robot_generator.Commands;

public class DownloadCsvCommand: ICommand
{
    
    private Action _execute;

    public DownloadCsvCommand(Action execute)
    {
        _execute = execute;
    }
    
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        _execute?.Invoke();
    }

    public event EventHandler? CanExecuteChanged;
}
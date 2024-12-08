using System.Windows.Input;
using robot_generator.Commands;

namespace robot_generator.VIewModels;

public class MainWindowViewModel: ViewModelBase
{
    private string _randomRoboPath;
    public ICommand generateGuidCommand { get; }

    public MainWindowViewModel()
    {
        generateGuidCommand = new GenerateRobot(GenerateRobot);
        
        string randomGuid = Guid.NewGuid().ToString();
        GenerateRobot($"https://robohash.org/{randomGuid}");
        
    }

    public string RandomGuid
    {
        get => _randomRoboPath;
        set
        {
            _randomRoboPath = value;
            OnPropertyChanged();
        }
    }

    private void GenerateRobot(string robotPath) => RandomGuid = robotPath;

}
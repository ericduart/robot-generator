using System.Windows.Input;
using robot_generator.Commands;

namespace robot_generator.VIewModels;

public class MainWindowViewModel: ViewModelBase
{
    private string _randomRoboPath;
    public ICommand GenerateGuidCommand { get; }
    public ICommand AddRobotToFavoriteCommand { get; }

    public MainWindowViewModel()
    {
        GenerateGuidCommand = new GenerateRobot(GenerateRobot);
        AddRobotToFavoriteCommand = new AddRobotToFavoriteCommand(AddFavoriteRobot);
        
        string randomGuid = Guid.NewGuid().ToString();
        GenerateRobot($"https://robohash.org/{randomGuid}");
        
    }

    public string RandomRoboPath
    {
        get => _randomRoboPath;
        set
        {
            _randomRoboPath = value;
            OnPropertyChanged();
        }
    }

    private void GenerateRobot(string robotPath) => RandomRoboPath = robotPath;

    private void AddFavoriteRobot()
    {
        Console.WriteLine("Saving...");
    }

}
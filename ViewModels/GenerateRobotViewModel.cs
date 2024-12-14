using System.Windows.Input;
using robot_generator.Commands;
using robot_generator.Data;
using robot_generator.Models;
using robot_generator.Repositories;

namespace robot_generator.VIewModels;

public class GenerateRobotViewModel : ViewModelBase
{
    private string _randomRobotId;
    public ICommand GenerateGuidCommand { get; }
    public ICommand AddRobotToFavoriteCommand { get; }

    public GenerateRobotViewModel()
    {
        GenerateGuidCommand = new GenerateRobot(GenerateRobot);
        AddRobotToFavoriteCommand = new AddRobotToFavoriteCommand(AddFavoriteRobot);
        
        string randomGuid = Guid.NewGuid().ToString();
        GenerateRobot(randomGuid);
        
    }

    public string RandomRoboPath
    {
        get => $"https://robohash.org/{_randomRobotId}";
        set
        {
            _randomRobotId = value;
            OnPropertyChanged();
        }
    }

    private void GenerateRobot(string robotId) => RandomRoboPath = robotId;

    private void AddFavoriteRobot()
    {
        try
        {
            using (var robotRepository = new RobotRepository())
            {
                robotRepository.Add(new Robot()
                {
                    RobotId = _randomRobotId,
                    RobotPath = $"https://robohash.org/{_randomRobotId}"
                });

                robotRepository.SaveChanges();

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
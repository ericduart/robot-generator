using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
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
    public ICommand DownloadCsvCommand { get; }

    public GenerateRobotViewModel()
    {
        GenerateGuidCommand = new GenerateRobotCommand(GenerateRobot);
        AddRobotToFavoriteCommand = new AddRobotToFavoriteCommand(AddFavoriteRobot);

        DownloadCsvCommand = new DownloadCsvCommand(DownloadCsv);
        
        
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

    private void DownloadCsv()
    {
        try
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();

            var response = openFolderDialog.ShowDialog();
            
            if (response == null || (bool)!response) return;

            string path = Path.Combine(openFolderDialog.FolderName,
                $"Robots_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv");
            
            IEnumerable<Robot> robots;

            using (var robotRepository = new RobotRepository())
            {
                robots = robotRepository.GetAll();
            }
            
            if (!robots.Any()) return;

            using (var file = new StreamWriter(path, false, Encoding.UTF8))
            {
                file.WriteLine("id;route");

                foreach (var robot in robots)
                {
                    file.WriteLine($"{robot.RobotId};{robot.RobotPath}");
                }
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
using System.Windows.Input;
using robot_generator.Commands;

namespace robot_generator.VIewModels;

public class MainWindowViewModel: ViewModelBase
{

    public ViewModelBase CurrentViewModel { get; }
    
    public MainWindowViewModel()
    {
        CurrentViewModel = new GenerateRobotViewModel();

    }


}
using System.Configuration;
using System.Data;
using System.Windows;
using robot_generator.VIewModels;

namespace robot_generator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow mainWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel()
        };
        
        mainWindow.Show();
    }
}
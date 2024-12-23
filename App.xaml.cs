﻿using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using robot_generator.Data;
using robot_generator.Models;
using robot_generator.Repositories;
using robot_generator.VIewModels;

namespace robot_generator;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {

        using (var robotRepository = new RobotRepository())
        {
            robotRepository.Migrate();
        }
        
        MainWindow mainWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel()
        };
        
        mainWindow.Show();
    }
}
using Avalonia.Controls;
using ScreenBreak.Models;
using ScreenBreak.Services;
using System;

namespace ScreenBreak.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var service = new SettingsService();
            //service.SaveSettings(new UserSettings());
            //UserSettings userSettings = service.LoadSettings();
            //Console.WriteLine(userSettings.EnableSound);
            //Console.WriteLine(userSettings.BreakSeconds);
            
        }

        public void Dashboard_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new DashboardView();
        }

        public void Settings_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new SettingsView();
        }
    }
}
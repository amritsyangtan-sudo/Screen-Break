using Avalonia.Controls;
using ScreenBreak.Models;
using ScreenBreak.Services;
using System;
using System.Collections.Generic;

namespace ScreenBreak.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            HistoryService historyService = new();

            List<SessionRecord> records =
                historyService.LoadHistory();

            records.Add(
                new SessionRecord
                {
                    StartTime = DateTime.Now.AddMinutes(-20),
                    EndTime = DateTime.Now,
                    SessionType = "Work",
                    DurationSeconds = 1200,
                    Completed = true
                });

            historyService.SaveHistory(records);

        }

        public void Dashboard_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new DashboardView();
        }

        public void Settings_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new SettingsView();
        }

        public void History_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainContent.Content = new HistoryView();
        }
    }
}
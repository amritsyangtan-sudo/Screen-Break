using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ScreenBreak.Models;
using ScreenBreak.Services;
using System;

namespace ScreenBreak.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
        LoadUserSettings();
    }

    public void SaveSettings_Click(object? sender, RoutedEventArgs e)
    {

        var settings = new UserSettings
        {
            WorkMinutes = int.Parse(WorkMinuteTextBox.Text!),
            BreakSeconds = int.Parse(BreakDurationTextBox.Text!),
            EnableSound = EnableSoundCheckBox.IsChecked ?? false,
            EnableNotifications = EnableNotificationCheckBox.IsChecked ?? false
        };


        var userSettingsService = new SettingsService();
        userSettingsService.SaveSettings(settings);

    }

    private void LoadUserSettings()
    {
        SettingsService settingsService = new SettingsService();
        UserSettings userSettings = settingsService.LoadSettings();
        WorkMinuteTextBox.Text = userSettings.WorkMinutes.ToString();
        BreakDurationTextBox.Text = userSettings.BreakSeconds.ToString();
        EnableNotificationCheckBox.IsChecked = userSettings.EnableSound;
        EnableNotificationCheckBox.IsChecked = userSettings.EnableNotifications;

    }
}
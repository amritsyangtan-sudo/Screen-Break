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
    private UserSettings _userSettings = new UserSettings();
    private SettingsService _settinggService = new SettingsService();
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

        _settinggService.SaveSettings(settings);

    }

    private void LoadUserSettings()
    {
        _userSettings = _settinggService.LoadSettings();
        WorkMinuteTextBox.Text = _userSettings.WorkMinutes.ToString();
        BreakDurationTextBox.Text = _userSettings.BreakSeconds.ToString();
        EnableSoundCheckBox.IsChecked = _userSettings.EnableSound;
        EnableNotificationCheckBox.IsChecked = _userSettings.EnableNotifications;
    }

    public void ResetSettings_Click(object? sender, RoutedEventArgs e)
    {
        var resetSettings = new UserSettings();
        WorkMinuteTextBox.Text = resetSettings.WorkMinutes.ToString();
        BreakDurationTextBox.Text = resetSettings.BreakSeconds.ToString();
        EnableSoundCheckBox.IsChecked = resetSettings.EnableSound;
        EnableNotificationCheckBox.IsChecked = resetSettings.EnableNotifications;
    }
}
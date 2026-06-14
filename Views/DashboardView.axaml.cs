using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using ScreenBreak.Services;
using ScreenBreak.Models;
using System;
using Avalonia.Threading;


namespace ScreenBreak.Views;

public partial class DashboardView : UserControl
{
    private SettingsService _settingService = new SettingsService();
    private UserSettings _userSettings = new UserSettings();
    private int _remainingSeconds;
    private DispatcherTimer _timer = new();
    public DashboardView()
    {
        InitializeComponent();
        LoadSettings();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += TimerTick;
    }

    private void LoadSettings()
    {
      _userSettings = _settingService.LoadSettings();
        _remainingSeconds = _userSettings.WorkMinutes * 60;
        UpdateTimerDisplay();

    }

    private void UpdateTimerDisplay()
    {
        TimeSpan time = TimeSpan.FromSeconds(_remainingSeconds);
        TimerTextBlock.Text = time.ToString(@"mm\:ss");
        TimerHintBlock.Text = time.ToString(@"mm\:ss");
      
    }

    private void TimerTick(object ? sender, EventArgs e)
    {
        if(_remainingSeconds > 0)
        {
            _remainingSeconds--;
            CurrentSessionTextBox.Text = "Work Time";
            CurrentSessionRing.Text = "Work Time";
            UpdateTimerDisplay();
        }
        else
        {
            _timer.Stop();
            CurrentSessionTextBox.Text = "Break Time";
            CurrentSessionRing.Text = "Break Time";
        }
    }

    private void StartButton_Click(object ? sender, RoutedEventArgs e)
    {
        LoadSettings();
        _timer.Start();
    }

    private void PauseButton_Click(object ? sender, RoutedEventArgs e)
    {
        _timer.Stop();
    }
}
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using ScreenBreak.Services;
using ScreenBreak.Models;
using System;
using Avalonia.Threading;
using System.Media;
using System.Collections.Generic;



namespace ScreenBreak.Views;

public partial class DashboardView : UserControl
{
    private SettingsService _settingService = new SettingsService();
    private UserSettings _userSettings = new UserSettings();
    private HistoryService _historyService = new HistoryService();
    private int _remainingSeconds;
    private DispatcherTimer _timer = new();
    private int _workSeconds;
    private int _breakSeconds;
    private bool _isWorkSession = true;
    private DateTime _sessionStartTime;

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
        _workSeconds = _userSettings.WorkMinutes * 60;
        _breakSeconds = _userSettings.BreakSeconds;
        _remainingSeconds = _workSeconds;
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
            UpdateTimerDisplay();
        }
        else
        {

            SwitchSession();
        }
    }

    private void StartButton_Click(object ? sender, RoutedEventArgs e)
    {
        _sessionStartTime = DateTime.Now;
        _timer.Start();
    }

    private void PauseButton_Click(object ? sender, RoutedEventArgs e)
    {
        _timer.Stop();
    }

    private void SwitchSession()
    {
        SaveSessionRecord();
        //  PlayNotificationSound();
        if (_isWorkSession)
        {
            _isWorkSession = false;
            _remainingSeconds = _breakSeconds;
            CurrentSessionTextBox.Text = "Break Time";
            CurrentSessionRing.Text = "Break Time";
            TimerRing.BorderBrush = Avalonia.Media.Brushes.DodgerBlue;
            

        }
        else
        {
            _isWorkSession = true;
            _remainingSeconds = _workSeconds;
            CurrentSessionTextBox.Text = "Work Time";
            CurrentSessionRing.Text = "Work Time";
            TimerRing.BorderBrush = Avalonia.Media.Brushes.LimeGreen;
           // SaveSessionRecord();
        }
        UpdateTimerDisplay();
    }

    private void PlayNotificationSound()
    {
        if (_userSettings.EnableSound)
        {
            Console.Beep();
        }
    }

    private void SaveSessionRecord()
    {
        List<SessionRecord> sessionRecords = _historyService.LoadHistory();
        sessionRecords.Add(
        new SessionRecord
        {
            StartTime = _sessionStartTime,
            EndTime = DateTime.Now,
            SessionType = _isWorkSession
                ? "Work"
                : "Break",

            DurationSeconds =
                _isWorkSession
                    ? _workSeconds
                    : _breakSeconds,

            Completed = true
        });

        _historyService.SaveHistory(sessionRecords);
    }
}


using Avalonia.Threading;
using ScreenBreak.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ScreenBreak.Services
{
    public class TimerService
    {
        private UserSettings _userSettings;
        private HistoryService _historyService;
        private DispatcherTimer _dispatcherTimer = new();
        private int _remainingTime;
        private int workingTime;
        private int breakTime;
        private string userSettingsFile;
        private string historyFile;

        public TimerService(int workingTime, int breakTime, UserSettings userSettings, HistoryService historyService, string userSettingFile, string historyFile)
        {
            this.workingTime = workingTime;
            this.breakTime = breakTime;
            this._userSettings = userSettings;
            this._historyService = historyService;
            this.userSettingsFile = userSettingFile;
            this.historyFile = historyFile;
        }

        public void StartTimer(int tickTimer)
        {
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(tickTimer);
            _dispatcherTimer.Tick += TimerTick;
        }

        public void TimerTick(object ? sender, EventArgs e)
        {
            if(_remainingTime > 0)
            {
                _remainingTime--;
                UpdateDisplay();
            }
            else
            {

            }
        }


        public void UpdateDisplay()
        {

        }

        public void SaveSessionRecord()
        {

        }
        

    }
}


/*
 


    creation of dispatcher timer
    set tick interval
    when tick even fires call the method that udpates the ui and remaining seconds
    
    

    work_seconds =  load from settings   
    break_seconds = load from settings
    
    creation of dispatcher timer
    timer tick interval setup
    
          
    
1.  timer start
        
2.  timer stop
    
3.  switch session
    
4.  call UI update
    

button click
    start continuous till stop
 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenBreak.Models
{
    public class UserSettings
    {
        public int WorkMinutes { get; set; } = 20;
        public int BreakSeconds { get; set; } = 20;
        public bool EnableSound { get; set; } = true;
        public bool EnableNotifications { get; set; } = true;

    }
}

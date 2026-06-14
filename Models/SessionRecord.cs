using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenBreak.Models
{
    public class SessionRecord
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SessionType { get; set; }
        public int DurationSeconds { get; set; }
        public bool Completed { get; set; }
    }
}

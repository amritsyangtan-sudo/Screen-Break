using ScreenBreak.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace ScreenBreak.Services
{
    public class HistoryService
    {
        private const string HistoryFileName = "history.json";

        public void SaveHistory(List<SessionRecord> records)
        {
            string historyJson = JsonSerializer.Serialize
                (records,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            File.WriteAllText(HistoryFileName, historyJson);
        }

        public List<SessionRecord> LoadHistory()
        {
            if (File.Exists(HistoryFileName))
            {
                string historyJson = File.ReadAllText(HistoryFileName);
                List<SessionRecord>? records = JsonSerializer.Deserialize< List<SessionRecord>>(historyJson);
                if(records != null)
                {
                    return records;
                }
            }
            return new List<SessionRecord>();
        }
    }
}

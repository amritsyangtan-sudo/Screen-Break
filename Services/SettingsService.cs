using ScreenBreak.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace ScreenBreak.Services
{
    public class SettingsService
    {
        private const string SettingsFileName = "settings.json";
        public void SaveSettings(UserSettings userSettings)
        {
            string userSettingsJson = JsonSerializer.Serialize(userSettings, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(SettingsFileName, userSettingsJson);

        }

        public UserSettings LoadSettings()
        {
            if (File.Exists(SettingsFileName))
            {
                string userSettingsJson = File.ReadAllText(SettingsFileName);
                UserSettings? userSettings = JsonSerializer.Deserialize<UserSettings>(userSettingsJson);
                if(userSettings != null)
                {
                    return userSettings;
                }
            }
            return new UserSettings();
        }
    }
}

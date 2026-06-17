using ScreenBreak.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace ScreenBreak.Services
{
    public class JSONService
    {

        //public JSONService(SessionRecord sessionRecord, UserSettings userSettings)
        //{
        //    this._sessionRecord = sessionRecord;
        //    this._userSettings = userSettings;
        //}

        public T LoadSettings<T>(string fileName, T data)
        {
            string jsonFile = File.ReadAllText(fileName);
            T? objectData = JsonSerializer.Deserialize<T>(jsonFile);
            if (objectData != null)
            {
                return objectData;
            }
            return data;
        }

        public void SaveSettings<T>(string fileName, T objectData)
        {
            try { 
            string settingsJsonFile = JsonSerializer.Serialize(objectData, new JsonSerializerOptions { WriteIndented =true});
            File.WriteAllText(fileName, settingsJsonFile);
            }
            catch(Exception exception)
            {
               
            }
        }

        

    }
}

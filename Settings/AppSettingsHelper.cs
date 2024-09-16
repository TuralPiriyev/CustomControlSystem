using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;


namespace CustomControlSystem.Settings
{
    public class AppSettingsHelper
    {
        private readonly string _configurationPath;

        public AppSettingsHelper(string configurationPath)
        {
            _configurationPath = configurationPath;
        }

        public AppSettings GetSettings()
        {
            string filename = Path.Combine(_configurationPath, "CustomControlSystem.Settings");
            if(File.Exists(filename) == false) 
            {
                return null;
            }
            string settingsRaw = File.ReadAllText(filename);

            AppSettings? settings = JsonConvert.DeserializeObject<AppSettings>(settingsRaw);

            return settings;
        }

        public void SaveSettings(AppSettings settings)
        {
            string settingsRaw = JsonConvert.SerializeObject(settings);
            string filename = Path.Combine( _configurationPath, "CustomControlSystem");
            File.WriteAllText(filename, settingsRaw);
        }
    }
}

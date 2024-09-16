using CustomControlSystem.Core.Domain.Entities;
using CustomControlSystem.Core.Domain.Enums;
using CustomControlSystem.Core.Domain.Repositories;
using CustomControlSystem.Factory;
using CustomControlSystem.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControlSystem
{
    public class ApplicationContext
    {
        private static AppSettings _defaultSettings = new AppSettings
        {
            DbHost = "localhost",
            DbName = "default",
            DbPort = 1433,
            DbType = DatabaseType.SqlServer,
            Username = "",
            Password = "",
            WindowsAuthentication = true


        };
         
        public static string ConfigurationPath
        {
            get
            {
                string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                settingsPath = Path.Combine(settingsPath, "CustomControlSystem");
                if(Directory.Exists(settingsPath) ==  false)
                {
                    Directory.CreateDirectory(settingsPath);
                }
                return settingsPath;
            }
        }
        public static AppSettings Settings { get; private set; }

        public static IUnitOfWork DB { get; private set; }
        public static User CurrentUser { get; set; }


        public static void Initialize()
        {
            Settings = InitializeSettings();

            DB = DbFactory.Get(Settings);
        }
        private static AppSettings InitializeSettings()
        {
            string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            settingsPath = Path.Combine(settingsPath, "UniversityManagement");
            AppSettingsHelper helper = new AppSettingsHelper(settingsPath);

            AppSettings? appSettings = helper.GetSettings();
            if (appSettings is null)
            {
                appSettings = _defaultSettings;
            }
            return appSettings;
        }
    }
}

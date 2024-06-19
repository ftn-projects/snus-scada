using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SCADACore.Infrastructure.Utils
{
    public static class ApplicationConfig
    {
        private static readonly string DataFolder = Path.Combine(Home, "SCADA_App_Data");
        public static string ScadaConfig { get; } = Path.Combine(DataFolder, "scadaConfig.xml");
        public static string AlarmsLog { get; } = Path.Combine(DataFolder, "alarmsLog.txt");

        private static string Home => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        static ApplicationConfig()
        {
            if (!Directory.Exists(DataFolder))
                Directory.CreateDirectory(DataFolder);
        }
    }
}
using System.IO;
using System.Web.Hosting;

namespace SCADACore.Infrastructure.Utils
{
    public static class ApplicationConfig
    {
        public static readonly string DataFolder = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data");
        public static string ScadaConfig { get; } = Path.Combine(DataFolder, "scadaConfig.xml");
        public static string AlarmsLog { get; } = Path.Combine(DataFolder, "alarmsLog.txt");
    }
}
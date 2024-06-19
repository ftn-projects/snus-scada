using System.IO;
using SCADACore.Infrastructure.Domain.Alarm;

namespace SCADACore.Infrastructure.Utils
{
    public class AlarmInvocationLogger
    {
        private static readonly string LogPath = ApplicationConfig.AlarmsLog;

        public static void Log(AlarmInvocation alarm)
        {
            using (var writer = File.AppendText(LogPath))
            {
                writer.WriteLine(alarm);
            }
        }

        public static void Wipe()
        {
            File.OpenWrite(LogPath).Close();
        }
    }
}
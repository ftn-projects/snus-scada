using System.IO;
using SCADACore.Infrastructure.Domain.Alarm;

namespace SCADACore.Infrastructure.Utils
{
    public class AlarmInvocationLogger
    {
        private const string LogPath = "alarmsLog.txt";

        public static void Log(AlarmInvocation alarm)
        {
            using (var writer = File.AppendText(LogPath))
            {
                writer.WriteLine(alarm);
            }
        }
    }
}
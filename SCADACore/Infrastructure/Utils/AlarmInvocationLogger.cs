using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
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
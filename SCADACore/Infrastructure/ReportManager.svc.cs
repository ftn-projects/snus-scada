using SCADACore.Infrastructure.Contract;
using SCADACore.Infrastructure.Service;
using System.Collections.Generic;
using System.Linq;
using SCADACore.Infrastructure.Repository;
using System.Collections.Concurrent;

namespace SCADACore.Infrastructure
{
    public class ReportManager : IReportManager
    {
        public List<Alarm> GetAlarmsByPriority(ConcurrentDictionary<string, Tag> Tags, Priority priority)
        {
            return Tags.Values
                .OfType<AnalogInputTag>()  
                .SelectMany(tag => tag.Alarms)  
                .Where(alarm => alarm.Priority == priority)  
                .ToList();
        }
    }
}

using SCADACore.Infrastructure.Contract;
using System.Collections.Generic;
using System.Linq;
using SCADACore.Infrastructure.Repository;
using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure
{
    public class ReportManager : IReportManager
    {

        public List<Alarm> GetAlarmsByPriority(Priority priority)
        {
            return TagRepository.Tags.Values
                .OfType<AnalogInputTag>()  
                .SelectMany(tag => tag.Alarms)  
                .Where(alarm => alarm.Priority == priority)  
                .ToList();
        }
    }
}

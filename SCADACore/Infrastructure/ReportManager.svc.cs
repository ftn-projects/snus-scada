using SCADACore.Infrastructure.Contract;
using System.Collections.Generic;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Enumeration;

namespace SCADACore.Infrastructure
{
    public class ReportManager : IReportManager
    {

        public List<Alarm> GetAlarmsByPriority(Priority priority)
        {
            return new List<Alarm>();
        }
    }
}

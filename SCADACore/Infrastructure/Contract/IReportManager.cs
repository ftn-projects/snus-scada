using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ServiceModel;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract]
    public interface IReportManager
    {
        [OperationContract]
        List<Alarm> GetAlarmsByPriority(ConcurrentDictionary<string, Tag> tags, Priority priority);
    }
}

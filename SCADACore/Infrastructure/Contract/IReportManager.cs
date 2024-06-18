using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ServiceModel;
using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract]
    public interface IReportManager
    {
        [OperationContract]
        List<Alarm> GetAlarmsByPriority(Priority priority);
    }
}

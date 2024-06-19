using System;
using System.Collections.Generic;
using System.ServiceModel;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract]
    public interface IReportManager
    {
        [OperationContract]
        List<AlarmInvocation> GetAlarmsByPriority(Priority priority);
        [OperationContract]
        List<AlarmInvocation> GetAlarmsInPeriod(DateTime start, DateTime end);
        [OperationContract]
        List<InputTagValue> GetDigitalInputTagValues();
        [OperationContract]
        List<InputTagValue> GetAnalogInputTagValues();
        [OperationContract]
        List<InputTagValue> GetInputTagValuesByTagName(string tagName);
        [OperationContract]
        List<InputTagValue> GetInputTagValuesByPeriod(DateTime start, DateTime end);
    }
}

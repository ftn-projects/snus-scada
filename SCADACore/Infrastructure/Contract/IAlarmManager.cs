using SCADACore.Infrastructure.Domain;
using System.Collections.Generic;
using System.ServiceModel;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract]
    internal interface IAlarmManager
    {
        [OperationContract]
        List<Alarm> GetAlarmsForTag(string token, string tagName);
        [OperationContract]
        bool AddAlarmForTag(string token, string tagName, Alarm alarm);
        [OperationContract]
        bool RemoveAlarmForTag(string token, string tagName, string alarmName);

    }
}

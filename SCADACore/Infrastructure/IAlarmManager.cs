using SCADACore.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADACore.Infrastructure
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

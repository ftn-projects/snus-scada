using System.ServiceModel;
using SCADACore.Infrastructure.Domain.Alarm;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract(CallbackContract = typeof(IAlarmDisplayCallback))]
    public interface IAlarmDisplay
    {
        [OperationContract(IsInitiating = true)]
        void InitAlarmDisplay();
    }

    [ServiceContract]
    public interface IAlarmDisplayCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnAlarmInvoked(AlarmInvocation alarm);
    }
}

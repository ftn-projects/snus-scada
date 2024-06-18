using System.ServiceModel;
using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;

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
        void OnAlarmInvoked(InputTagValue tag, Alarm alarm, double value);
    }
}

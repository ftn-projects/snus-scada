using System.ServiceModel;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IRtuDriver
    {
        [OperationContract(IsInitiating = true)]
        void InitRtuDriver(string publicKey);
        [OperationContract(IsOneWay = true)]
        void UpdateValue(int address, double value, byte[] signature);
    }
}

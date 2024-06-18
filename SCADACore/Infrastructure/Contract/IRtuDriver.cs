using System.ServiceModel;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract]
    public interface IRtuDriver
    {
        [OperationContract(IsInitiating = true)]
        void InitRtuDriver(); // TODO register private key
        [OperationContract(IsOneWay = true)]
        void UpdateValue(int address, double value); // TODO add signature
    }
}

using System.ServiceModel;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract]
    public interface IRtuDriver
    {
        [OperationContract(IsInitiating = true)]
        void InitRtuDriver(string publicKey); // TODO register private key
        [OperationContract(IsOneWay = true)]
        void UpdateValue(int address, double value, byte[] signature); // TODO add signature
    }
}

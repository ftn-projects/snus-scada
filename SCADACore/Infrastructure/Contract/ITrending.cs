using System.ServiceModel;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract(CallbackContract = typeof(ITrendingCallback))]
    internal interface ITrending
    {
        [OperationContract(IsInitiating = true)]
        void InitTrending();
    }

    [ServiceContract]
    internal interface ITrendingCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnTrendingTagPrint(InputTagValue value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure
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

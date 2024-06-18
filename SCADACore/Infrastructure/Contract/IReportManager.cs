using System.Collections.Generic;
using System.ServiceModel;

namespace SCADACore.Infrastructure.Contract
{
    [ServiceContract]
    public interface IReportManager
    {
        [OperationContract]
        IEnumerable<string> GetSomeReport();
    }
}

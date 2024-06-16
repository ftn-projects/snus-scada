using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SCADACore.Infrastructure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDatabaseManager" in both code and config file together.
    [ServiceContract]
    public interface IDatabaseManager
    {
        [OperationContract]
        bool TurnScanOn(string token, string tagName);
        [OperationContract]
        bool TurnScanOff(string token, string tagName);
        [OperationContract]
        bool ChangeOutputValue(string token, string tagName, double newValue);
        [OperationContract]
        double GetOutputValue(string token, string tagName);
    }
}

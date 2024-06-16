using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SCADACore.Infrastructure
{
    [ServiceContract]
    public interface ITagManager
    {
        [OperationContract]
        bool AddDigitalInputTag(string token, DigitalInputTag digitalInputTag);
        [OperationContract]
        bool AddDigitalOutputTag(string token , DigitalOutputTag digitalOutputTag);
        [OperationContract]
        bool AddAnalogInputTag(string token,  AnalogInputTag analogInputTag);
        [OperationContract]
        bool AddAnalogOutputTag(string token, AnalogOutputTag analogOutputTag);
        [OperationContract]
        bool RemoveTag(string token, string TagName);
        [OperationContract]
        TagsState GetTagsState(string token);
    }
}

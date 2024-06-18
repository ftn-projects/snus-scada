using System.ServiceModel;
using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure.Contract
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
        bool RemoveTag(string token, string tagName);
        [OperationContract]
        TagsState GetTagsState(string token);
    }
}

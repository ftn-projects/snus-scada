using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure.Service
{
    public interface ITagService
    {
        bool AddDigitalInputTag(DigitalInputTag digitalInputTag);
        bool AddDigitalOutputTag(DigitalOutputTag digitalOutputTag);
        bool AddAnalogInputTag(AnalogInputTag analogInputTag);
        bool AddAnalogOutputTag(AnalogOutputTag analogOutputTag);
        bool RemoveTag(string TagName);
        bool TurnScanOn(string tagName);
        bool TurnScanOff(string tagName);
        bool ChangeOutputValue(string tagName, double newValue);
        bool GetOutputValue(string tagName);
        TagsState GetTagsState();
    }
}

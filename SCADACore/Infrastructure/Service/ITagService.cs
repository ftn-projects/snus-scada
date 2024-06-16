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
        double GetOutputValue(string tagName);
        TagsState GetTagsState();
        List<Alarm> GetAlarmsForTag(string tagName);
        bool AddAlarmForTag(string tagName, Alarm alarm);
        bool RemoveAlarmForTag(string tagName, string alarmName);
    }
}

using System.Collections.Generic;
using SCADACore.Infrastructure.Domain.Alarm;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;

namespace SCADACore.Infrastructure.Service
{
    public interface ITagService
    {
        bool AddTag(Tag tag);
        bool RemoveTag(string tagName);
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

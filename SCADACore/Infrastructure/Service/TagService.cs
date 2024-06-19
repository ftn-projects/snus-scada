using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using SCADACore.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using SCADACore.Infrastructure.Domain.Alarm;

namespace SCADACore.Infrastructure.Service
{
    public class TagService : ITagService
    {
        public bool AddAlarmForTag(string tagName, Alarm alarm)
        {
            Tag t = TagRepository.Tags[tagName];
            if(t is AnalogInputTag tag)
            {
                if (tag.Alarms.Any(x => x.Name == alarm.Name)) return false;
                tag.Alarms.Add(alarm);
                return TagRepository.SaveChanges();
            }
            return false;

        }
        
        public bool AddTag(Tag tag)
        {
            var added = TagRepository.Tags.TryAdd(tag.TagName, tag);
            if (!added) return false;
            return TagRepository.SaveChanges();
        }

        public bool ChangeOutputValue(string tagName, double newValue)
        {
            List<OutputTag> outputTags = TagRepository.GetTypeOfTags<OutputTag>();
            OutputTag tag = outputTags.Find(x => x.TagName == tagName);
            if (tag == null) return false;
            
            tag.InitialValue = newValue;
            return TagRepository.SaveChanges();
        }

        public List<Alarm> GetAlarmsForTag(string tagName)
        {
            Tag tag = TagRepository.Tags[tagName];
            if(tag is AnalogInputTag analogInputTag)
            {
                if(analogInputTag.Alarms != null && analogInputTag.Alarms.Count() > 0) return analogInputTag.Alarms;
                return new List<Alarm>();
            }
            return new List<Alarm>();
        }

        public double GetOutputValue(string tagName)
        {
            List<OutputTag> outputTags = TagRepository.GetTypeOfTags<OutputTag>();
            OutputTag tag = outputTags.Find(x => x.TagName == tagName);
            if (tag == null) return 0;

            return tag.InitialValue;

        }

        public TagsState GetTagsState()
        {
            TagsState tags = new TagsState()
            {
                AnalogInputTags = TagRepository.GetTypeOfTags<AnalogInputTag>().ToArray(),
                AnalogOutputTags = TagRepository.GetTypeOfTags<AnalogOutputTag>().ToArray(),
                DigitalInputTags = TagRepository.GetTypeOfTags<DigitalInputTag>().ToArray(),
                DigitalOutputTags = TagRepository.GetTypeOfTags<DigitalOutputTag>().ToArray(),
            };
            return tags;
        }

        public bool RemoveAlarmForTag(string tagName, string alarmName)
        {
            Tag t = TagRepository.Tags[tagName];
            if(t is AnalogInputTag tag)
            {
                Alarm a = tag.Alarms.Find(x => x.Name == alarmName);
                tag.Alarms.Remove(a);
                return TagRepository.SaveChanges();
            }
            return false;
        }

        public bool RemoveTag(string tagName)
        {
            var success = TagRepository.Tags.TryRemove(tagName, out _);
            if (success) TagRepository.SaveChanges();
            return success;
        }

        public bool TurnScanOff(string tagName)
        {
            var tag = TagRepository.Tags[tagName];
            if (!(tag is InputTag inputTag)) 
                return false;
            
            inputTag.Scan = false;
            return TagRepository.SaveChanges();
        }

        public bool TurnScanOn(string tagName)
        {
            var tag = TagRepository.Tags[tagName];
            if (!(tag is InputTag inputTag)) 
                return false;

            inputTag.Scan = false;
            return TagRepository.SaveChanges();
        }
    }
}
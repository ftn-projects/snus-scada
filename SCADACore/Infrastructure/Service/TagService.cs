using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using SCADACore.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCADACore.Infrastructure.Service
{
    public class TagService : ITagService
    {
        private static TagRepository _tagRepository = new TagRepository();

        public bool AddAlarmForTag(string tagName, Alarm alarm)
        {
            Tag t = _tagRepository.Tags.Find(x => tagName == x.TagName);
            if(t != null && t is AnalogInputTag tag)
            {
                if (tag.Alarms.Any(x => x.Name == alarm.Name)) return false;
                tag.Alarms.Add(alarm);
                return _tagRepository.SaveChanges();
            }
            return false;

        }

        public bool AddAnalogInputTag(AnalogInputTag analogInputTag)
        {
            if(_tagRepository.Tags.Any(x => x.TagName == analogInputTag.TagName)) return false;
            _tagRepository.Tags.Add(analogInputTag);
            return _tagRepository.SaveChanges();
        }

        public bool AddAnalogOutputTag(AnalogOutputTag analogOutputTag)
        {
            if(_tagRepository.Tags.Any(x => x.TagName == analogOutputTag.TagName)) return false;
            _tagRepository.Tags.Add(analogOutputTag);
            return _tagRepository.SaveChanges();
        }

        public bool AddDigitalInputTag(DigitalInputTag digitalInputTag)
        {
            if(_tagRepository.Tags.Any(x => x.TagName == digitalInputTag.TagName)) return false;
            _tagRepository.Tags.Add(digitalInputTag);
            return _tagRepository.SaveChanges();
        }

        public bool AddDigitalOutputTag(DigitalOutputTag digitalOutputTag)
        {
            if(_tagRepository.Tags.Any(x => x.TagName == digitalOutputTag.TagName)) return false;
            _tagRepository.Tags.Add(digitalOutputTag);
            return _tagRepository.SaveChanges();
        }

        public bool ChangeOutputValue(string tagName, double newValue)
        {
            List<OutputTag> outputTags = _tagRepository.GetTypeOfTags<OutputTag>();
            OutputTag tag = outputTags.Find(x => x.TagName == tagName);
            if (tag == null) return false;
            
            tag.InitialValue = newValue;
            return _tagRepository.SaveChanges();
        }

        public List<Alarm> GetAlarmsForTag(string tagName)
        {
            Tag tag = _tagRepository.Tags.Find(x => x.TagName == tagName);
            if(tag != null && tag is AnalogInputTag analogInputTag)
            {
                if(analogInputTag.Alarms != null && analogInputTag.Alarms.Count() > 0) return analogInputTag.Alarms;
                return new List<Alarm>();
            }
            return new List<Alarm>();
        }

        public double GetOutputValue(string tagName)
        {
            List<OutputTag> outputTags = _tagRepository.GetTypeOfTags<OutputTag>();
            OutputTag tag = outputTags.Find(x => x.TagName == tagName);
            if (tag == null) return 0;

            return tag.InitialValue;

        }

        public TagsState GetTagsState()
        {
            TagsState tags = new TagsState()
            {
                AnalogInputTags = _tagRepository.GetTypeOfTags<AnalogInputTag>().ToArray(),
                AnalogOutputTags = _tagRepository.GetTypeOfTags<AnalogOutputTag>().ToArray(),
                DigitalInputTags = _tagRepository.GetTypeOfTags<DigitalInputTag>().ToArray(),
                DigitalOutputTags = _tagRepository.GetTypeOfTags<DigitalOutputTag>().ToArray(),
            };
            return tags;
        }

        public bool RemoveAlarmForTag(string tagName, string alarmName)
        {
            Tag t = _tagRepository.Tags.Find(x => tagName == x.TagName);
            if(t != null && t is AnalogInputTag tag)
            {
                Alarm a = tag.Alarms.Find(x => x.Name == alarmName);
                tag.Alarms.Remove(a);
                return _tagRepository.SaveChanges();
            }
            return false;
        }

        public bool RemoveTag(string TagName)
        {
            var tag = _tagRepository.Tags.SingleOrDefault(x => x.TagName == TagName);
            if (tag != null) return _tagRepository.Tags.Remove(tag);
            return false;
        }

        public bool TurnScanOff(string tagName)
        {
            List<InputTag> tags = _tagRepository.GetTypeOfTags<InputTag>();
            tags.Any(x => x.TagName == tagName);

            InputTag tag = (InputTag) _tagRepository.Tags.Find(x => x.TagName == tagName);

            if (tag != null)
            {
                tag.Scan = false;
                return _tagRepository.SaveChanges();
            }

            return false;
        }

        public bool TurnScanOn(string tagName)
        {
            List<InputTag> tags = _tagRepository.GetTypeOfTags<InputTag>();
            tags.Any(x => x.TagName == tagName);

            InputTag tag = (InputTag) _tagRepository.Tags.Find(x => x.TagName == tagName);

            if (tag != null)
            {
                tag.Scan = true;
                return _tagRepository.SaveChanges();
            }

            return false;
        }
    }
}
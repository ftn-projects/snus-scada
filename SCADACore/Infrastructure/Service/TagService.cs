using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Tag;
using SCADACore.Infrastructure.Repository;
using System;
using System.Linq;

namespace SCADACore.Infrastructure.Service
{
    public class TagService : ITagService
    {
        private static TagRepository _tagRepository = new TagRepository();

        public bool AddAnalogInputTag(AnalogInputTag analogInputTag)
        {
            _tagRepository.AnalogInputTags.Add(analogInputTag);
            return _tagRepository.SaveChanges();
        }

        public bool AddAnalogOutputTag(AnalogOutputTag analogOutputTag)
        {
            _tagRepository.AnalogOutputTags.Add(analogOutputTag);
            return _tagRepository.SaveChanges();
        }

        public bool AddDigitalInputTag(DigitalInputTag digitalInputTag)
        {
            _tagRepository.DigitalInputTags.Add(digitalInputTag);
            return _tagRepository.SaveChanges();
        }

        public bool AddDigitalOutputTag(DigitalOutputTag digitalOutputTag)
        {
            _tagRepository.DigitalOutputTags.Add(digitalOutputTag);
            return _tagRepository.SaveChanges();
        }

        public bool ChangeOutputValue(string tagName, double newValue)
        {
            throw new NotImplementedException();
        }

        public bool GetOutputValue(string tagName)
        {
            throw new NotImplementedException();
        }

        public TagsState GetTagsState()
        {
            TagsState tags = new TagsState()
            {
                analogInputTags = _tagRepository.AnalogInputTags.ToArray(),
                analogOutputTags = _tagRepository.AnalogOutputTags.ToArray(),
                digitalInputTags = _tagRepository.DigitalInputTags.ToArray(),
                digitalOutputTags = _tagRepository.DigitalOutputTags.ToArray()
            };
            return tags;
        }

        public bool RemoveTag(string TagName)
        {
            var digitalInputTag = _tagRepository.DigitalInputTags.SingleOrDefault(x => x.TagName == TagName);
            if (digitalInputTag != null)
            {
                _tagRepository.DigitalInputTags.Remove(digitalInputTag);
                return _tagRepository.SaveChanges();
            }

            var digitalOutputTag = _tagRepository.DigitalOutputTags.SingleOrDefault(x => x.TagName == TagName);
            if (digitalOutputTag != null)
            {
                _tagRepository.DigitalOutputTags.Remove(digitalOutputTag);
                return _tagRepository.SaveChanges();
            }

            var analogOutputTag = _tagRepository.AnalogOutputTags.SingleOrDefault(x => x.TagName == TagName);
            if (analogOutputTag != null)
            {
                _tagRepository.AnalogOutputTags.Remove(analogOutputTag);
                return _tagRepository.SaveChanges();
            }

            var analogInputTag = _tagRepository.AnalogInputTags.SingleOrDefault(x => x.TagName == TagName);
            if (analogInputTag != null)
            {
                _tagRepository.AnalogOutputTags.Remove(analogOutputTag);
                return _tagRepository.SaveChanges();
            }
            return false;
        }

        public bool TurnScanOff(string tagName)
        {
            DigitalInputTag dtag = _tagRepository.DigitalInputTags.Find(x => x.TagName == tagName);
            if (dtag != null) 
            {
                dtag.Scan = false;
                return _tagRepository.SaveChanges();
            }

            AnalogInputTag atag = _tagRepository.AnalogInputTags.Find(x => x.TagName == tagName);
            if (atag != null)
            {
                atag.Scan = false;
                return _tagRepository.SaveChanges();
            }

            return false;
        }

        public bool TurnScanOn(string tagName)
        {
            DigitalInputTag dtag = _tagRepository.DigitalInputTags.Find(x => x.TagName == tagName);
            if (dtag != null) 
            {
                dtag.Scan = true;
                return _tagRepository.SaveChanges();
            }

            AnalogInputTag atag = _tagRepository.AnalogInputTags.Find(x => x.TagName == tagName);
            if (atag != null)
            {
                atag.Scan = true;
                return _tagRepository.SaveChanges();
            }

            return false;
        }
    }
}
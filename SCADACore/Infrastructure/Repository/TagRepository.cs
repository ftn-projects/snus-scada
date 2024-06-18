using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Domain.Enumeration;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SCADACore.Infrastructure.Repository
{
    public static class TagRepository
    {
        private static readonly string DATA_URL = "C:\\Fakultet\\Semestar 6\\Softver Nadzorno-Upravljackih Sistema\\projekat\\snus-scada\\SCADACore\\App_Data\\scadaConfig.xml"; 
        private static readonly object Locker = new object();

        public static ConcurrentDictionary<string, Tag> Tags { get; } = new ConcurrentDictionary<string, Tag>();

        static TagRepository() 
        {
            LoadAnalogInputTags();
            LoadAnalogOutputTags();
            LoadDigitalInputTags();
            LoadDigitalOutputTags();
        }
        
        private static void LoadDigitalOutputTags()
        {
            XElement xmlData = XElement.Load(DATA_URL);
            IEnumerable<XElement> digitalgOutputTagsXML = xmlData.Descendants("DigitalOutputTag");
            if (digitalgOutputTagsXML.Count() < 1) return;
            List<DigitalOutputTag> tags = (from tag in digitalgOutputTagsXML
                                 select new DigitalOutputTag()
                                 {
                                     TagName = tag.Attribute("TagName").Value,
                                     Description = tag.Attribute("Description").Value,  
                                     IOAddress = Convert.ToInt32(tag.Attribute("IOAddress").Value),
                                     InitialValue = Convert.ToDouble(tag.Attribute("InitialValue").Value)
                                 }).ToList();
            tags.ForEach(x => Tags[x.TagName] = x);
        }

        private static void LoadDigitalInputTags()
        {
            XElement xmlData = XElement.Load(DATA_URL);
            IEnumerable<XElement> digitalInputTagsXML = xmlData.Descendants("DigitalInputTag");
            if (digitalInputTagsXML.Count() < 1) return;
            List<DigitalInputTag> tags = (from tag in digitalInputTagsXML
                                select new DigitalInputTag()
                                {
                                    TagName = tag.Attribute("TagName").Value,
                                    Description = tag.Attribute("Description").Value,
                                    IOAddress = Convert.ToInt32(tag.Attribute("IOAddress").Value),
                                    DriverType = EnumUtils.ParseEnum<DriverType>(tag.Attribute("Driver").Value),
                                    Scan = Convert.ToBoolean(tag.Attribute("Scan").Value),
                                    ScanTime = Convert.ToDouble(tag.Attribute("ScanTime").Value)
                                }).ToList();
            tags.ForEach(x => Tags[x.TagName] = x);
        }

        private static void LoadAnalogOutputTags()
        {
            XElement xmlData = XElement.Load(DATA_URL);
            IEnumerable<XElement> analogOutputTagsXML = xmlData.Descendants("AnalogOutputTag");
            if (analogOutputTagsXML.Count() < 1) return;
            List<AnalogOutputTag> tags = (from tag in  analogOutputTagsXML
                               select new AnalogOutputTag()
                               {
                                   TagName = tag.Attribute("TagName").Value,
                                   Description = tag.Attribute("Description").Value,
                                   IOAddress = Convert.ToInt32(tag.Attribute("IOAddress").Value),
                                   HighLimit = Convert.ToDouble(tag.Attribute("HighLimit").Value),
                                   LowLimit = Convert.ToDouble(tag.Attribute("LowLimit").Value),
                                   InitialValue = Convert.ToDouble(tag.Attribute("InitialValue").Value),
                                   Units = tag.Attribute("Units").Value
                               }).ToList();
            tags.ForEach(x => Tags[x.TagName] = x);
        }

        private static void LoadAnalogInputTags()
        {
            XElement xmlData = XElement.Load(DATA_URL);
            IEnumerable<XElement> analogInputTagsXML = xmlData.Descendants("AnalogInputTag");
            if (analogInputTagsXML.Count() < 1) return;
            List<AnalogInputTag> tags = (from tag in analogInputTagsXML
                               select new AnalogInputTag()
                               {
                                   TagName = tag.Attribute("TagName").Value,
                                   Description = tag.Attribute("Description").Value,
                                   DriverType = EnumUtils.ParseEnum<DriverType>(tag.Attribute("Driver").Value),
                                   IOAddress = Convert.ToInt32(tag.Attribute("IOAddress").Value),
                                   ScanTime = Convert.ToDouble(tag.Attribute("ScanTime").Value),
                                   Scan = Convert.ToBoolean(tag.Attribute("Scan").Value),
                                   LowLimit = Convert.ToDouble(tag.Attribute("LowLimit").Value),
                                   HighLimit = Convert.ToDouble(tag.Attribute("HighLimit").Value),
                                   Units = tag.Attribute("Units").Value,
                                   Alarms = GetAlarmsFromXMLData(tag)
                               }).ToList();
            tags.ForEach(x => Tags[x.TagName] = x);
        }
        
        private static List<Alarm> GetAlarmsFromXMLData(XElement xmlData)
        {
            IEnumerable<XElement> alarmsXML = xmlData.Descendants("Alarm");
            if (alarmsXML.Count() < 1) return new List<Alarm>();
            return (from alarm in alarmsXML
                     select new Alarm
                     {
                         AlarmType = EnumUtils.ParseEnum<AlarmType>(alarm.Attribute("AlarmType").Value),
                         Priority = EnumUtils.ParseEnum<Priority>(alarm.Attribute("Priority").Value),
                         Units = alarm.Attribute("Units").Value,
                         LimitValue = Convert.ToDouble(alarm.Attribute("LimitValue").Value)
                     }).ToList();
        }
        
        public static bool SaveChanges()
        {
            XDocument xmlDocument = new XDocument();
            XElement tagsHolder = new XElement("Tags");
            foreach(var tag in Tags.Values)
            {
                tagsHolder.Add(tag.GetXmlRepresentation());
            }
            xmlDocument.Add(tagsHolder);
            xmlDocument.Save(DATA_URL);

            return true;
        }

        public static List<T> GetTypeOfTags<T>()
        {
            return Tags.OfType<T>().ToList();
        }
    }
}